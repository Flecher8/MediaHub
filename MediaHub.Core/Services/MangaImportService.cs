using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ImportDtos.MangaImportDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class MangaImportService : IMangaImportService
{
    private readonly IMediaContentTypeRepository _typeRepo;
    private readonly IMediaContentRepository _mcRepo;
    private readonly IMediaContentPictureRepository _picRepo;
    private readonly IGenreRepository _genreRepo;
    private readonly IMangaRepository _mangaRepo;
    private readonly IMangaAuthorRepository _authorRepo;

    public MangaImportService(
        IMediaContentTypeRepository typeRepo,
        IMediaContentRepository mcRepo,
        IMediaContentPictureRepository picRepo,
        IGenreRepository genreRepo,
        IMangaRepository mangaRepo,
        IMangaAuthorRepository authorRepo)
    {
        _typeRepo = typeRepo;
        _mcRepo = mcRepo;
        _picRepo = picRepo;
        _genreRepo = genreRepo;
        _mangaRepo = mangaRepo;
        _authorRepo = authorRepo;
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
        var dtos = await JsonSerializer.DeserializeAsync<List<MangaImportDto>>(jsonStream, opts);
        if (dtos is null) return;

        // get “Manga” media-content type
        var mangaType = (await _typeRepo.GetFilteredItemsAsync(t => t.Name == "Manga"))
                        .FirstOrDefault()
                        ?? throw new InvalidOperationException("MediaContentType 'Manga' not found");

        foreach (var dto in dtos)
        {
            // skip if title exists
            if ((await _mcRepo.GetFilteredItemsAsync(mc => mc.Title == dto.Title)).Any())
                continue;

            // 1) MediaContent
            var mc = new MediaContent
            {
                Title = dto.Title,
                Description = dto.Synopsis ?? "",
                Rating = dto.Mean,
                ReleaseDate = ParseDate(dto.Start_Date),
                MainPictureLink = dto.Main_Picture?.Large ?? dto.Main_Picture?.Medium,
                MediaContentTypeId = mangaType.TypeId
            };
            mc = await _mcRepo.AddAsync(mc);

            // 2) Pictures
            foreach (var pic in dto.Pictures)
            {
                var link = pic.Large ?? pic.Medium ?? "";
                await _picRepo.AddAsync(new MediaContentPicture
                {
                    MediaContentId = mc.MediaContentId,
                    PictureLink = link
                });
            }

            // 3) Genres
            foreach (var g in dto.Genres)
            {
                var eg = (await _genreRepo.GetFilteredItemsAsync(x => x.Name == g.Name))
                         .FirstOrDefault();
                if (eg != null)
                    mc.Genres.Add(eg);
            }
            await _mcRepo.UpdateAsync(mc);

            // 4) Manga entity
            var manga = new Manga
            {
                MediaContentId = mc.MediaContentId,
                Rank = dto.Rank,
                StartDate = ParseDate(dto.Start_Date),
                EndDate = dto.End_Date is null
                                     ? DateTime.Now
                                     : ParseDate(dto.End_Date),
                NumberOfVolumes = dto.Num_Volumes,
                NumberOfChapters = dto.Num_Chapters
            };

            // 5) Authors upsert
            foreach (var a in dto.Authors)
            {
                var fullName = $"{a.Node.First_Name} {a.Node.Last_Name}".Trim();
                var existing = (await _authorRepo
                    .GetFilteredItemsAsync(x => x.Name == fullName))
                    .FirstOrDefault();
                var author = existing
                           ?? await _authorRepo.AddAsync(new MangaAuthor { Name = fullName });
                manga.MangaAuthors.Add(author);
            }

            // 6) save Manga
            await _mangaRepo.AddAsync(manga);
        }
    }
}
