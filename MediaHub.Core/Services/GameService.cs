using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.GameDtos;

namespace MediaHub.Core.Services;
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepo;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepo, IMapper mapper)
    {
        _gameRepo = gameRepo;
        _mapper = mapper;
    }

    public async Task<GameDto?> GetByMediaContentIdAsync(Guid mediaContentId)
    {
        var list = await _gameRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(g => g.MediaContentId == mediaContentId)
            .Include(g => g.MediaContent)
            .Include(g => g.GamePlatforms)
            .Include(g => g.GameDevelopers)
            .Include(g => g.GamePublishers)
            .Include(g => g.GameTags)
        );

        var entity = list.FirstOrDefault();
        return entity == null
            ? null
            : _mapper.Map<GameDto>(entity);
    }
}
