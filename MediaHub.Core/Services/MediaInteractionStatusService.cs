using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MediaInteractionStatusDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class MediaInteractionStatusService : IMediaInteractionStatusService
{
    private readonly IMediaInteractionStatusRepository _misRepo;
    private readonly IContentStatusRepository _csRepo;
    private readonly IEvaluationRepository _evalRepo;
    private readonly IMediaContentRepository _mediaRepo;
    private readonly IRecommendationCollectionRepository _recRepo;
    private readonly IMapper _mapper;

    public MediaInteractionStatusService(
        IMediaInteractionStatusRepository misRepo,
        IContentStatusRepository csRepo,
        IEvaluationRepository evalRepo,
        IMediaContentRepository mediaRepo,
        IRecommendationCollectionRepository recRepo,
        IMapper mapper)
    {
        _misRepo = misRepo;
        _csRepo = csRepo;
        _evalRepo = evalRepo;
        _mediaRepo = mediaRepo;
        _recRepo = recRepo;
        _mapper = mapper;
    }

    public async Task<MediaInteractionStatusDto> AddAsync(CreateMediaInteractionStatusDto dto)
    {
        // validate media & collection exist
        if (await _mediaRepo.GetByIdAsync(dto.MediaContentId) is null)
            throw new ArgumentException("MediaContent not found.");
        if (await _recRepo.GetByIdAsync(dto.RecommendationCollectionId) is null)
            throw new ArgumentException("RecommendationCollection not found.");

        // **prevent duplicates**: no two statuses with same media+collection
        var dup = await _misRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mis =>
                mis.MediaContentId == dto.MediaContentId &&
                mis.RecommendationCollectionId == dto.RecommendationCollectionId));
        if (dup.Any())
            throw new ArgumentException("This media is already in that collection.");

        // load defaults
        var status = (await _csRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(s => s.Name == "In Progress"))).FirstOrDefault()
            ?? throw new InvalidOperationException("'In Progress' ContentStatus is missing.");
        var eval = (await _evalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(e => e.Name == "None"))).FirstOrDefault()
            ?? throw new InvalidOperationException("'None' Evaluation is missing.");

        // create & save
        var entity = new MediaInteractionStatus
        {
            MediaContentId = dto.MediaContentId,
            RecommendationCollectionId = dto.RecommendationCollectionId,
            ContentStatusId = status.ContentStatusId,
            EvaluationId = eval.EvaluationId
        };
        await _misRepo.AddAsync(entity);

        // map back
        return _mapper.Map<MediaInteractionStatusDto>(entity);
    }

    public async Task<MediaInteractionStatusDto> UpdateAsync(UpdateMediaInteractionStatusDto dto)
    {
        var mis = await _misRepo.GetByIdAsync(dto.MediaInteractionStatusId)
                  ?? throw new KeyNotFoundException("MediaInteractionStatus not found.");

        // validate the new ContentStatus exists:
        var csList = await _csRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(c => c.ContentStatusId == dto.ContentStatusId));
        if (!csList.Any())
            throw new ArgumentException("ContentStatus not found.");
        mis.ContentStatusId = dto.ContentStatusId;

        // validate the new Evaluation exists:
        var evList = await _evalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(e => e.EvaluationId == dto.EvaluationId));
        if (!evList.Any())
            throw new ArgumentException("Evaluation not found.");
        mis.EvaluationId = dto.EvaluationId;

        await _misRepo.UpdateAsync(mis);
        return _mapper.Map<MediaInteractionStatusDto>(mis);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _misRepo.DeleteAsync(id);
    }

    public async Task<MediaInteractionStatusDto?> GetByIdAsync(Guid id)
    {
        // include the navs so AutoMapper has all the data
        var list = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis => mis.MediaInteractionStatusId == id)
            .Include(mis => mis.MediaContent)
            .Include(mis => mis.ContentStatus)
            .Include(mis => mis.Evaluation)
            .Include(mis => mis.RecommendationCollection)
        );

        var e = list.FirstOrDefault();
        return e == null ? null : _mapper.Map<MediaInteractionStatusDto>(e);
    }

    public async Task<List<MediaContentDto>> GetMediaByCollectionAsync(Guid recommendationCollectionId)
    {
        // load all statuses for that collection, including the MediaContent navigation and its children
        var list = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis => mis.RecommendationCollectionId == recommendationCollectionId)
            .Include(mis => mis.MediaContent)
            .Include(mis => mis.MediaContent.Genres)
            .Include(mis => mis.MediaContent.MediaContentPictures)
            .Include(mis => mis.MediaContent.MediaContentType)
        );

        // project to MediaContentDto
        return list
            .Select(mis => _mapper.Map<MediaContentDto>(mis.MediaContent))
            .ToList();
    }

    public async Task DeleteByCollectionAndMediaAsync(Guid recommendationCollectionId, Guid mediaContentId)
    {
        // find the matching status entry (there should be at most one)
        var matches = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis =>
                mis.RecommendationCollectionId == recommendationCollectionId &&
                mis.MediaContentId == mediaContentId));

        var mis = matches.FirstOrDefault();
        if (mis == null)
            throw new KeyNotFoundException("No MediaInteractionStatus found for that collection + media pair.");

        await _misRepo.DeleteAsync(mis.MediaInteractionStatusId);
    }
}
