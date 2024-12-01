using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.GamePlatformDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class GamePlatformsService : IGamePlatformsService
{
    private readonly IGamePlatformRepository _repository;
    private readonly IMapper _mapper;

    public GamePlatformsService(IGamePlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GamePlatformDto> CreateGamePlatformAsync(CreateGamePlatformDto dto)
    {
        var existingPlatform = await _repository.GetFilteredItemsAsync(p => p.Name == dto.Name);
        if (existingPlatform.Any())
        {
            throw new ArgumentException($"Game platform with name '{dto.Name}' already exists.");
        }

        var platform = _mapper.Map<GamePlatform>(dto);
        var createdPlatform = await _repository.AddAsync(platform);
        return _mapper.Map<GamePlatformDto>(createdPlatform);
    }

    public async Task UpdateGamePlatformAsync(UpdateGamePlatformDto dto)
    {
        var platform = await _repository.GetByIdAsync(dto.GamePlatformId);
        if (platform == null)
            throw new KeyNotFoundException("Game platform not found.");

        _mapper.Map(dto, platform);
        await _repository.UpdateAsync(platform);
    }

    public async Task DeleteGamePlatformAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<GamePlatformDto?> GetGamePlatformByIdAsync(Guid id)
    {
        var platform = await _repository.GetByIdAsync(id);
        return platform == null ? null : _mapper.Map<GamePlatformDto>(platform);
    }

    public async Task<List<GamePlatformDto>> GetAllGamePlatformsAsync()
    {
        var platforms = await _repository.GetAllAsync();
        return _mapper.Map<List<GamePlatformDto>>(platforms);
    }

    public async Task<GamePlatformDto?> GetGamePlatformByNameAsync(string name)
    {
        var platforms = await _repository.GetFilteredItemsAsync(p => p.Name == name);
        return platforms.FirstOrDefault() == null ? null : _mapper.Map<GamePlatformDto>(platforms.First());
    }
}
