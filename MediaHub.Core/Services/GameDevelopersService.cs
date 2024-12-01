using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.GameDeveloperDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class GameDevelopersService : IGameDevelopersService
{
    private readonly IGameDeveloperRepository _repository;
    private readonly IMapper _mapper;

    public GameDevelopersService(IGameDeveloperRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GameDeveloperDto> CreateGameDeveloperAsync(CreateGameDeveloperDto dto)
    {
        var existingDeveloper = await _repository.GetFilteredItemsAsync(d => d.Name == dto.Name);
        if (existingDeveloper.Any())
        {
            throw new ArgumentException($"Game developer with name '{dto.Name}' already exists.");
        }

        var developer = _mapper.Map<GameDeveloper>(dto);
        var createdDeveloper = await _repository.AddAsync(developer);
        return _mapper.Map<GameDeveloperDto>(createdDeveloper);
    }

    public async Task UpdateGameDeveloperAsync(UpdateGameDeveloperDto dto)
    {
        var developer = await _repository.GetByIdAsync(dto.GameDeveloperId);
        if (developer == null)
            throw new KeyNotFoundException("Game developer not found.");

        _mapper.Map(dto, developer);
        await _repository.UpdateAsync(developer);
    }

    public async Task DeleteGameDeveloperAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<GameDeveloperDto?> GetGameDeveloperByIdAsync(Guid id)
    {
        var developer = await _repository.GetByIdAsync(id);
        return developer == null ? null : _mapper.Map<GameDeveloperDto>(developer);
    }

    public async Task<List<GameDeveloperDto>> GetAllGameDevelopersAsync()
    {
        var developers = await _repository.GetAllAsync();
        return _mapper.Map<List<GameDeveloperDto>>(developers);
    }

    public async Task<GameDeveloperDto?> GetGameDeveloperByNameAsync(string name)
    {
        var developers = await _repository.GetFilteredItemsAsync(d => d.Name == name);
        return developers.FirstOrDefault() == null ? null : _mapper.Map<GameDeveloperDto>(developers.First());
    }
}
