using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MangaDtos;

namespace MediaHub.Core.Services;
public class MangaService : IMangaService
{
    private readonly IMangaRepository _mangaRepo;
    private readonly IMapper _mapper;

    public MangaService(IMangaRepository mangaRepo, IMapper mapper)
    {
        _mangaRepo = mangaRepo;
        _mapper = mapper;
    }

    public async Task<MangaDto?> GetByMediaContentIdAsync(Guid mediaContentId)
    {
        var results = await _mangaRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(m => m.MediaContentId == mediaContentId)
            .Include(m => m.MediaContent)
            .Include(m => m.MangaAuthors)
        );

        var manga = results.FirstOrDefault();
        return manga == null
            ? null
            : _mapper.Map<MangaDto>(manga);
    }
}
