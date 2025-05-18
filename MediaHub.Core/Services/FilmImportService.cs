using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ImportDtos.MoviesDtos.FilmImportDtos;
using MediaHub.Models.Entities;
using Microsoft.Extensions.Logging;

namespace MediaHub.Core.Services;
public class FilmImportService : IFilmImportService
{
    private readonly IMediaContentTypeRepository _typeRepo;
    private readonly IMediaContentRepository _mcRepo;
    private readonly IGenreRepository _genreRepo;
    private readonly IActorRepository _actorRepo;
    private readonly IDirectorRepository _directorRepo;
    private readonly IMovieInfoRepository _miRepo;
    private readonly IFilmRepository _filmRepo;

    private readonly ILogger<FilmImportService> _logger;

    public FilmImportService(
        IMediaContentTypeRepository typeRepo,
        IMediaContentRepository mcRepo,
        IGenreRepository genreRepo,
        IActorRepository actorRepo,
        IDirectorRepository directorRepo,
        IMovieInfoRepository miRepo,
        IFilmRepository filmRepo,
        ILogger<FilmImportService> logger)
    {
        _typeRepo = typeRepo;
        _mcRepo = mcRepo;
        _genreRepo = genreRepo;
        _actorRepo = actorRepo;
        _directorRepo = directorRepo;
        _miRepo = miRepo;
        _filmRepo = filmRepo;

        _logger = logger;
    }

    private DateTime ParseDate(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return DateTime.Now;
        return DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
             ? d
             : DateTime.TryParse(s, out d) ? d : DateTime.Now;
    }

    public async Task ImportFromStreamAsync(Stream jsonStream)
    {
        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dtos = await JsonSerializer.DeserializeAsync<List<FilmImportDto>>(jsonStream, opts);
        if (dtos is null) return;

        // fetch “Film” media-type once
        var filmType = (await _typeRepo.GetFilteredItemsAsync(t => t.Name == "Film"))
                       .FirstOrDefault()
                   ?? throw new InvalidOperationException("MediaContentType ‘Film’ not found");

        // Logging
        var total = dtos.Count;
        int i = 0;

        foreach (var dto in dtos)
        {
            // Logging
            i++;

            // skip duplicates
            if ((await _mcRepo.GetFilteredItemsAsync(mc => mc.Title == dto.Original_Title)).Any())
                continue;

            // 1) MediaContent
            var mc = new MediaContent
            {
                Title = dto.Original_Title,
                Description = dto.Overview ?? "",
                Rating = dto.Vote_Average,
                ReleaseDate = ParseDate(dto.Release_Date),
                MainPictureLink = dto.Poster_Path is null
                                      ? null
                                      : "https://image.tmdb.org/t/p/original" + dto.Poster_Path,
                MediaContentTypeId = filmType.TypeId
            };
            mc = await _mcRepo.AddAsync(mc);

            // 2) Genres ↔ MediaContent
            foreach (var g in dto.Genres)
            {
                var eg = (await _genreRepo.GetFilteredItemsAsync(x => x.Name == g.Name))
                         .FirstOrDefault();
                if (eg != null)
                    mc.Genres.Add(eg);
            }
            await _mcRepo.UpdateAsync(mc);

            // 3) MovieInfo
            var mi = new MovieInfo
            {
                DurationInMinutes = dto.Runtime
            };

            // 4) Actors upsert
            foreach (var c in dto.Credits.Cast.Where(c => c.Known_For_Department == "Acting"))
            {
                var exists = (await _actorRepo.GetFilteredItemsAsync(a => a.Name == c.Name))
                             .FirstOrDefault();
                var actor = exists ?? await _actorRepo.AddAsync(new Actor { Name = c.Name });
                mi.Actors.Add(actor);
            }

            // 5) Directors upsert
            foreach (var c in dto.Credits.Crew.Where(c =>
                c.Known_For_Department == "Directing" && c.Department == "Directing"))
            {
                var exists = (await _directorRepo.GetFilteredItemsAsync(d => d.Name == c.Name))
                             .FirstOrDefault();
                var dir = exists ?? await _directorRepo.AddAsync(new Director { Name = c.Name });
                mi.Directors.Add(dir);
            }

            mi = await _miRepo.AddAsync(mi);

            // 6) Film → links MediaContent ↔ MovieInfo
            var film = new Film
            {
                MediaContentId = mc.MediaContentId,
                MovieInfoId = mi.MovieInfoId
            };
            await _filmRepo.AddAsync(film);

            // Logging
            _logger.LogInformation(
                "Imported film #{Index}/{Total}",
                i, total);
        }
    }
}
