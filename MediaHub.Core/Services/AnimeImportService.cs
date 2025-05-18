using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ImportDtos.AnimeImportDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class AnimeImportService : IAnimeImportService
{
    private readonly IMediaContentTypeRepository _typeRepo;
    private readonly IMediaContentRepository _mcRepo;
    private readonly IMediaContentPictureRepository _picRepo;
    private readonly IAnimeRepository _animeRepo;
    private readonly IAnimeStudioRepository _studioRepo;
    private readonly IGenreRepository _genreRepo;

    public AnimeImportService(
        IMediaContentTypeRepository typeRepo,
        IMediaContentRepository mcRepo,
        IMediaContentPictureRepository picRepo,
        IAnimeRepository animeRepo,
        IAnimeStudioRepository studioRepo,
        IGenreRepository genreRepo)
    {
        _typeRepo = typeRepo;
        _mcRepo = mcRepo;
        _picRepo = picRepo;
        _animeRepo = animeRepo;
        _studioRepo = studioRepo;
        _genreRepo = genreRepo;
    }

    public async Task ImportFromStreamAsync(Stream jsonStream)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dtos = await JsonSerializer.DeserializeAsync<List<AnimeImportDto>>(jsonStream, options);
        if (dtos is null) return;

        // fetch “Anime” media-type once
        var animeType = (await _typeRepo
            .GetFilteredItemsAsync(b => b.Name == "Anime"))
            .FirstOrDefault()
            ?? throw new InvalidOperationException("MediaContentType ‘Anime’ not found");

        foreach (var dto in dtos)
        {
            // — skip if we've already imported this title —
            var already = await _mcRepo
                .GetFilteredItemsAsync(m => m.Title == dto.Title);
            if (already.Any())
                continue;

            // 1) create MediaContent
            var mc = new MediaContent
            {
                Title = dto.Title,
                Description = dto.Synopsis,
                Rating = dto.Mean,
                ReleaseDate = ParseDate(dto.Start_Date),
                MainPictureLink = dto.Main_Picture?.Large ?? dto.Main_Picture?.Medium,
                MediaContentTypeId = animeType.TypeId
            };
            mc = await _mcRepo.AddAsync(mc);

            // 2) pictures
            foreach (var p in dto.Pictures)
            {
                var pic = new MediaContentPicture
                {
                    MediaContentId = mc.MediaContentId,
                    PictureLink = p.Large ?? p.Medium ?? ""
                };
                await _picRepo.AddAsync(pic);
            }

            // 3) anime row
            var anime = new Anime
            {
                MediaContentId = mc.MediaContentId,
                Rank = dto.Rank,
                NumberOfEpisodes = dto.Num_Episodes,
                StartDate = ParseDate(dto.Start_Date),
                EndDate = ParseDate(dto.Start_Date),
            };

            // 4) studios (upsert)
            foreach (var s in dto.Studios)
            {
                var existingStudio = (await _studioRepo
                    .GetFilteredItemsAsync(b => b.Name == s.Name))
                    .FirstOrDefault();
                var studio = existingStudio
                            ?? await _studioRepo.AddAsync(new AnimeStudio { Name = s.Name });
                anime.AnimeStudios.Add(studio);
            }

            // 5) genres (link only seeded ones)
            foreach (var g in dto.Genres)
            {
                var existingGenre = (await _genreRepo
                    .GetFilteredItemsAsync(x => x.Name == g.Name))
                    .FirstOrDefault();
                if (existingGenre != null)
                    mc.Genres.Add(existingGenre);
            }

            // persist the updated MediaContent ↔ Genre many-to-many
            await _mcRepo.UpdateAsync(mc);

            // 6) save Anime
            await _animeRepo.AddAsync(anime);
        }
    }

    private DateTime ParseDate(string? dateStr)
    {
        if (string.IsNullOrWhiteSpace(dateStr))
            return DateTime.Now;

        // Try full ISO date first: yyyy-MM-dd
        if (DateTime.TryParseExact(
                dateStr,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var fullDate))
        {
            return fullDate;
        }

        // Try just the year: yyyy
        if (DateTime.TryParseExact(
                dateStr,
                "yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var yearOnly))
        {
            // default to Jan 1st of that year
            return yearOnly;
        }

        // Fallback to whatever DateTime.Parse can do (or Today on failure)
        return DateTime.TryParse(dateStr, out var dt)
            ? dt
            : DateTime.Now;
    }
}
