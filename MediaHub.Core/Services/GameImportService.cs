using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models.Entities;
using MediaHub.Models.Dtos.ImportDtos.GameImportDtos;

namespace MediaHub.Core.Services;
public class GameImportService : IGameImportService
{
    private readonly IMediaContentTypeRepository _typeRepo;
    private readonly IMediaContentRepository _mcRepo;
    private readonly IMediaContentPictureRepository _picRepo;
    private readonly IGenreRepository _genreRepo;
    private readonly IGameRepository _gameRepo;
    private readonly IGameTagRepository _tagRepo;
    private readonly IGameDeveloperRepository _devRepo;
    private readonly IGamePublisherRepository _pubRepo;
    private readonly IGamePlatformRepository _platRepo;

    public GameImportService(
        IMediaContentTypeRepository typeRepo,
        IMediaContentRepository mcRepo,
        IMediaContentPictureRepository picRepo,
        IGenreRepository genreRepo,
        IGameRepository gameRepo,
        IGameTagRepository tagRepo,
        IGameDeveloperRepository devRepo,
        IGamePublisherRepository pubRepo,
        IGamePlatformRepository platRepo)
    {
        _typeRepo = typeRepo;
        _mcRepo = mcRepo;
        _picRepo = picRepo;
        _genreRepo = genreRepo;
        _gameRepo = gameRepo;
        _tagRepo = tagRepo;
        _devRepo = devRepo;
        _pubRepo = pubRepo;
        _platRepo = platRepo;
    }

    private DateTime ParseDate(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return DateTime.Now;
        if (DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
            return d;
        if (DateTime.TryParseExact(s, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            return d;
        return DateTime.TryParse(s, out d) ? d : DateTime.Now;
    }

    public async Task ImportFromStreamAsync(Stream jsonStream)
    {
        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dtos = await JsonSerializer.DeserializeAsync<List<GameImportDto>>(jsonStream, opts);
        if (dtos is null) return;

        // get “Game” type
        var gameType = (await _typeRepo.GetFilteredItemsAsync(b => b.Name == "Game"))
                       .FirstOrDefault()
                       ?? throw new InvalidOperationException("MediaContentType 'Game' not found");

        foreach (var dto in dtos)
        {
            // skip existing title
            if ((await _mcRepo.GetFilteredItemsAsync(m => m.Title == dto.Name)).Any())
                continue;

            // 1) MediaContent
            var mc = new MediaContent
            {
                Title = dto.Name,
                Description = dto.Description ?? "",
                Rating = dto.Rating,
                ReleaseDate = ParseDate(dto.Released),
                MainPictureLink = dto.Background_Image_Additional
                                     ?? dto.Background_Image,
                MediaContentTypeId = gameType.TypeId
            };
            mc = await _mcRepo.AddAsync(mc);

            // 2) screenshots
            foreach (var picDto in dto.Screenshots)
            {
                var link = picDto.Large ?? picDto.Medium ?? "";
                await _picRepo.AddAsync(new MediaContentPicture
                {
                    MediaContentId = mc.MediaContentId,
                    PictureLink = link
                });
            }

            // 3) genres
            foreach (var g in dto.Genres)
            {
                var eg = (await _genreRepo.GetFilteredItemsAsync(x => x.Name == g.Name))
                         .FirstOrDefault();
                if (eg != null) mc.Genres.Add(eg);
            }
            await _mcRepo.UpdateAsync(mc);

            // 4) Game entity
            var game = new Game
            {
                MediaContentId = mc.MediaContentId,
                MetacriticRating = dto.Metacritic ?? 0,
                PlaytimeHours = dto.Playtime,
                EsrbRating = 0 // if you want a raw field
            };

            // 5) Tags upsert
            foreach (var tagDto in dto.Tags)
            {
                // look for an existing tag by Name
                var existingTags = await _tagRepo.GetFilteredItemsAsync(t => t.Name == tagDto.Name);
                var tag = existingTags.FirstOrDefault()
                       ?? await _tagRepo.AddAsync(new GameTag { Name = tagDto.Name });
                game.GameTags.Add(tag);
            }

            // 6) Developers upsert
            foreach (var devDto in dto.Developers)
            {
                var existingDevs = await _devRepo.GetFilteredItemsAsync(d => d.Name == devDto.Name);
                var dev = existingDevs.FirstOrDefault()
                       ?? await _devRepo.AddAsync(new GameDeveloper { Name = devDto.Name });
                game.GameDevelopers.Add(dev);
            }

            // 7) Publishers upsert
            foreach (var pubDto in dto.Publishers)
            {
                var existingPubs = await _pubRepo.GetFilteredItemsAsync(p => p.Name == pubDto.Name);
                var pub = existingPubs.FirstOrDefault()
                       ?? await _pubRepo.AddAsync(new GamePublisher { Name = pubDto.Name });
                game.GamePublishers.Add(pub);
            }

            // 8) Platforms upsert
            foreach (var pltContainer in dto.Platforms)
            {
                // pull the actual name out of the nested DTO
                var platformName = pltContainer.Platform.Name;

                // look for an existing GamePlatform by Name
                var existingPlats = await _platRepo
                    .GetFilteredItemsAsync(p => p.Name == platformName);

                // if none found, create it
                var plat = existingPlats.FirstOrDefault()
                        ?? await _platRepo.AddAsync(new GamePlatform { Name = platformName });

                // link to this Game
                game.GamePlatforms.Add(plat);
            }

            // 9) Finally save the Game entity itself
            await _gameRepo.AddAsync(game);
        }
    }
}
