using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.GameTagDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class GameTagsService : IGameTagsService
{
    private readonly IGameTagRepository _repository;
    private readonly IMapper _mapper;

    public GameTagsService(IGameTagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GameTagDto> CreateGameTagAsync(CreateGameTagDto dto)
    {
        var existingTag = await _repository.GetFilteredItemsAsync(t => t.Name == dto.Name);
        if (existingTag.Any())
        {
            throw new ArgumentException($"Game tag with name '{dto.Name}' already exists.");
        }

        var tag = _mapper.Map<GameTag>(dto);
        var createdTag = await _repository.AddAsync(tag);
        return _mapper.Map<GameTagDto>(createdTag);
    }

    public async Task UpdateGameTagAsync(UpdateGameTagDto dto)
    {
        var tag = await _repository.GetByIdAsync(dto.GameTagId);
        if (tag == null)
            throw new KeyNotFoundException("Game tag not found.");

        _mapper.Map(dto, tag);
        await _repository.UpdateAsync(tag);
    }

    public async Task DeleteGameTagAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<GameTagDto?> GetGameTagByIdAsync(Guid id)
    {
        var tag = await _repository.GetByIdAsync(id);
        return tag == null ? null : _mapper.Map<GameTagDto>(tag);
    }

    public async Task<List<GameTagDto>> GetAllGameTagsAsync()
    {
        var tags = await _repository.GetAllAsync();
        return _mapper.Map<List<GameTagDto>>(tags);
    }

    public async Task<GameTagDto?> GetGameTagByNameAsync(string name)
    {
        var tags = await _repository.GetFilteredItemsAsync(t => t.Name == name);
        return tags.FirstOrDefault() == null ? null : _mapper.Map<GameTagDto>(tags.First());
    }
}
