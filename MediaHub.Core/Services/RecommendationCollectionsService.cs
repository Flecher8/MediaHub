using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.RecommendationCollectionDtos;
using MediaHub.Models.Dtos.RecommendationCollectionUserAccessDtos;
using MediaHub.Models.Dtos.UserDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class RecommendationCollectionsService : IRecommendationCollectionsService
{
    private readonly IRecommendationCollectionRepository _collectionsRepo;
    private readonly IUserRepository _userRepo;
    private readonly ICollectionUserRoleRepository _roleRepo;
    private readonly IRecommendationCollectionUserAccessRepository _accessRepo;
    private readonly IMapper _mapper;

    public RecommendationCollectionsService(
        IRecommendationCollectionRepository collectionsRepo,
        IUserRepository userRepo,
        ICollectionUserRoleRepository roleRepo,
        IRecommendationCollectionUserAccessRepository accessRepo,
        IMapper mapper)
    {
        _collectionsRepo = collectionsRepo;
        _userRepo = userRepo;
        _roleRepo = roleRepo;
        _accessRepo = accessRepo;
        _mapper = mapper;
    }

    public async Task<RecommendationCollectionDto> CreateCollectionAsync(CreateRecommendationCollectionDto dto)
    {
        // you might want to validate the user exists:
        var users = await _userRepo.GetFilteredItemsAsync(fb => fb.WithFilter(u => u.Id == dto.CreatorUserId));
        if (!users.Any())
            throw new ArgumentException("Creator user not found.");

        var entity = new RecommendationCollection
        {
            CreatorUserId = dto.CreatorUserId,
            Name = dto.Name
        };
        await _collectionsRepo.AddAsync(entity);

        var userEntity = (await _userRepo
             .GetFilteredItemsAsync(fb => fb.WithFilter(u => u.Id == dto.CreatorUserId)))
             .First();

        return new RecommendationCollectionDto
        {
            CollectionId = entity.CollectionId,
            Name = entity.Name,
            Creator = _mapper.Map<UserDto>(userEntity)
        };
    }

    public async Task DeleteCollectionAsync(Guid collectionId)
    {
        // load
        var col = await _collectionsRepo.GetByIdAsync(collectionId);
        if (col == null)
            throw new ArgumentException("Collection not found.");

        // do not let user delete their last collection
        var userCols = await GetUserCollectionsAsync(col.CreatorUserId);
        if (userCols.Count <= 1 && userCols.Any(c => c.CollectionId == collectionId))
            throw new InvalidOperationException("Cannot delete your last remaining collection.");

        // remove all access rows first
        var accesses = await _accessRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(a => a.RecommendationCollectionId == collectionId));
        foreach (var a in accesses)
            await _accessRepo.DeleteAsync(a.UserAccessId);

        // then delete the collection
        await _collectionsRepo.DeleteAsync(collectionId);
    }

    public async Task AddUserToCollectionAsync(AddUserToCollectionDto dto)
    {
        var col = await _collectionsRepo.GetByIdAsync(dto.CollectionId);
        if (col == null)
            throw new ArgumentException("Collection not found.");

        // find the user
        var user = (await _userRepo
            .GetFilteredItemsAsync(fb => fb.WithFilter(u => u.Email == dto.UserEmail)))
            .FirstOrDefault();
        if (user == null)
            throw new ArgumentException("User not found.");

        // you may not add the creator to their own collection
        if (user.Id == col.CreatorUserId)
            throw new ArgumentException("Cannot add the collection creator as a member.");

        // ensure they don’t already have access
        var exists = await _accessRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(a =>
                a.RecommendationCollectionId == dto.CollectionId &&
                a.UserId == user.Id));
        if (exists.Any())
            throw new ArgumentException("User already has access to this collection.");

        // lookup Editor role
        var editor = (await _roleRepo
            .GetFilteredItemsAsync(fb => fb.WithFilter(r => r.Name == "Editor")))
            .FirstOrDefault();
        if (editor == null)
            throw new InvalidOperationException("Editor role is missing from database.");

        // add the access
        var access = new RecommendationCollectionUserAccess
        {
            RecommendationCollectionId = dto.CollectionId,
            UserId = user.Id,
            CollectionUserRoleId = editor.CollectionUserRoleId
        };
        await _accessRepo.AddAsync(access);
    }

    public async Task RemoveUserFromCollectionAsync(Guid collectionId, Guid userId)
    {
        var accesses = await _accessRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(a =>
                a.RecommendationCollectionId == collectionId &&
                a.UserId == userId));
        var access = accesses.FirstOrDefault();
        if (access != null)
            await _accessRepo.DeleteAsync(access.UserAccessId);
    }

    public async Task<List<RecommendationCollectionDto>> GetUserCollectionsAsync(Guid userId)
    {
        // Collections this user created
        var own = await _collectionsRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(c => c.CreatorUserId == userId));

        // Access entries for this user
        var userAccesses = await _accessRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(a => a.UserId == userId));

        // Which other collections (not owned) they have access to?
        var otherIds = userAccesses
            .Select(a => a.RecommendationCollectionId)
            .Where(id => own.All(c => c.CollectionId != id))
            .Distinct()
            .ToList();

        // Fetch those “other” collections
        var others = otherIds.Any()
            ? await _collectionsRepo.GetFilteredItemsAsync(fb =>
                fb.WithFilter(c => otherIds.Contains(c.CollectionId)))
            : new List<RecommendationCollection>();

        // Combine
        var all = own.Concat(others).ToList();

        // If they have none at all, auto-create a default
        if (!all.Any())
        {
            var created = await CreateCollectionAsync(new CreateRecommendationCollectionDto
            {
                CreatorUserId = userId,
                Name = "Default Collection"
            });
            return new List<RecommendationCollectionDto> { created };
        }

        // Load all creators in one go
        var creatorIds = all.Select(c => c.CreatorUserId).Distinct().ToList();
        var creators = await _userRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(u => creatorIds.Contains(u.Id)));

        // Eagerly load every access record for those collections, including User & Role
        var allCollectionIds = all.Select(c => c.CollectionId).ToList();
        var allAccessEntities = await _accessRepo.GetFilteredItemsAsync(fb =>
        {
            fb.WithFilter(a => allCollectionIds.Contains(a.RecommendationCollectionId))
              .Include(a => a.User)
              .Include(a => a.CollectionUserRole);
        });

        // Project into DTOs
        var result = all.Select(c =>
        {
            var creator = creators.First(u => u.Id == c.CreatorUserId);

            return new RecommendationCollectionDto
            {
                CollectionId = c.CollectionId,
                Name = c.Name,
                Creator = _mapper.Map<UserDto>(creator),
                RecommendationCollectionUserAccesses = allAccessEntities
                    .Where(a => a.RecommendationCollectionId == c.CollectionId)
                    .Select(a => _mapper.Map<RecommendationCollectionUserAccessDto>(a))
                    .ToList()
            };
        })
        .ToList();

        return result;
    }

}
