using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.FilmDtos;

namespace MediaHub.Core.Services;
public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepo;
    private readonly IMapper _mapper;

    public FilmService(IFilmRepository filmRepo, IMapper mapper)
    {
        _filmRepo = filmRepo;
        _mapper = mapper;
    }

    public async Task<FilmDto?> GetByMediaContentIdAsync(Guid mediaContentId)
    {
        var films = await _filmRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(f => f.MediaContentId == mediaContentId)
            .Include(f => f.MediaContent)
            .Include(f => f.MovieInfo!)
            .Include(f => f.MovieInfo!.Actors)
            .Include(f => f.MovieInfo!.Directors)
        );

        var film = films.FirstOrDefault();
        return film == null
            ? null
            : _mapper.Map<FilmDto>(film);
    }
}
