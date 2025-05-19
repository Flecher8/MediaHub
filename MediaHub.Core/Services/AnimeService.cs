using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.AnimeDtos;

namespace MediaHub.Core.Services;
public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepo;
    private readonly IMapper _mapper;

    public AnimeService(IAnimeRepository animeRepo, IMapper mapper)
    {
        _animeRepo = animeRepo;
        _mapper = mapper;
    }

    public async Task<AnimeDto?> GetByMediaContentIdAsync(Guid mediaContentId)
    {
        var list = await _animeRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(a => a.MediaContentId == mediaContentId)
            .Include(a => a.MediaContent)
            .Include(a => a.AnimeStudios)
        );

        var anime = list.FirstOrDefault();
        return anime == null
            ? null
            : _mapper.Map<AnimeDto>(anime);
    }
}
