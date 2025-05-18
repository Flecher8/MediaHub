using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ImportDtos.MoviesDtos.SerialImportDtos;
using MediaHub.Models.Entities;
using Microsoft.Extensions.Logging;

namespace MediaHub.Core.Services;
public class SerialImportService : ISerialImportService
{
    private readonly IMediaContentTypeRepository _typeRepo;
    private readonly IMediaContentRepository _mcRepo;
    private readonly IGenreRepository _genreRepo;
    private readonly IActorRepository _actorRepo;
    private readonly IDirectorRepository _directorRepo;
    private readonly IMovieInfoRepository _miRepo;
    private readonly ISerialRepository _serialRepo;

    private readonly ILogger<SerialImportService> _logger;

    public SerialImportService(
        IMediaContentTypeRepository typeRepo,
        IMediaContentRepository mcRepo,
        IGenreRepository genreRepo,
        IActorRepository actorRepo,
        IDirectorRepository directorRepo,
        IMovieInfoRepository miRepo,
        ISerialRepository serialRepo,
        ILogger<SerialImportService> logger
        )
    {
        _typeRepo = typeRepo;
        _mcRepo = mcRepo;
        _genreRepo = genreRepo;
        _actorRepo = actorRepo;
        _directorRepo = directorRepo;
        _miRepo = miRepo;
        _serialRepo = serialRepo;

        _logger = logger;
    }

    private DateTime ParseDate(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return DateTime.Now;
        return DateTime.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
             ? d
             : DateTime.TryParse(s, out d) ? d
             : DateTime.Now;
    }

    public async Task ImportFromStreamAsync(Stream jsonStream)
    {
        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dtos = await JsonSerializer.DeserializeAsync<List<SerialImportDto>>(jsonStream, opts);
        if (dtos is null) return;

        var serialType = (await _typeRepo.GetFilteredItemsAsync(t => t.Name == "Serial"))
                         .FirstOrDefault()
                     ?? throw new InvalidOperationException("MediaContentType ‘Serial’ not found");

        // Logging
        var total = dtos.Count;
        int i = 0;

        foreach (var dto in dtos)
        {
            // Logging
            i++;

            // skip if already exists
            if ((await _mcRepo.GetFilteredItemsAsync(mc => mc.Title == dto.Name)).Any())
                continue;

            // 1) MediaContent
            var mc = new MediaContent
            {
                Title = dto.Name,
                Description = dto.Overview ?? "",
                Rating = dto.Vote_Average,
                ReleaseDate = ParseDate(dto.First_Air_Date),
                MainPictureLink = dto.Poster_Path is null
                                  ? null
                                  : "https://image.tmdb.org/t/p/original" + dto.Poster_Path,
                MediaContentTypeId = serialType.TypeId
            };
            mc = await _mcRepo.AddAsync(mc);

            // 2) Genres
            foreach (var g in dto.Genres)
            {
                var eg = (await _genreRepo.GetFilteredItemsAsync(x => x.Name == g.Name))
                         .FirstOrDefault();
                if (eg != null) mc.Genres.Add(eg);
            }
            await _mcRepo.UpdateAsync(mc);

            // 3) MovieInfo (use episode_run_time if you had it; here we default to 0)
            var mi = new MovieInfo
            {
                DurationInMinutes = 0
            };

            // 4) Actors
            foreach (var c in dto.Credits.Cast.Where(c => c.Known_For_Department == "Acting"))
            {
                var exists = (await _actorRepo.GetFilteredItemsAsync(a => a.Name == c.Name))
                             .FirstOrDefault();
                var actor = exists ?? await _actorRepo.AddAsync(new Actor { Name = c.Name });
                mi.Actors.Add(actor);
            }

            // 5) Directors
            foreach (var c in dto.Credits.Crew.Where(c =>
                c.Known_For_Department == "Directing" && c.Department == "Directing"))
            {
                var exists = (await _directorRepo.GetFilteredItemsAsync(d => d.Name == c.Name))
                             .FirstOrDefault();
                var dir = exists ?? await _directorRepo.AddAsync(new Director { Name = c.Name });
                mi.Directors.Add(dir);
            }

            mi = await _miRepo.AddAsync(mi);

            // 6) Serial entity
            var serial = new Serial
            {
                MediaContentId = mc.MediaContentId,
                MovieInfoId = mi.MovieInfoId,
                NumberOfSeasons = dto.Number_Of_Seasons,
                NumberOfEpisodes = dto.Number_Of_Episodes
            };
            await _serialRepo.AddAsync(serial);

            // Logging
            _logger.LogInformation(
                "Imported serial #{Index}/{Total}",
                i, total);
        }
    }
}
