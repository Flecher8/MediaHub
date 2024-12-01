using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.GamePublisherDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class GamePublishersService : IGamePublishersService
{
    private readonly IGamePublisherRepository _repository;
    private readonly IMapper _mapper;

    public GamePublishersService(IGamePublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GamePublisherDto> CreateGamePublisherAsync(CreateGamePublisherDto dto)
    {
        var existingPublisher = await _repository.GetFilteredItemsAsync(p => p.Name == dto.Name);
        if (existingPublisher.Any())
        {
            throw new ArgumentException($"Game publisher with name '{dto.Name}' already exists.");
        }

        var publisher = _mapper.Map<GamePublisher>(dto);
        var createdPublisher = await _repository.AddAsync(publisher);
        return _mapper.Map<GamePublisherDto>(createdPublisher);
    }

    public async Task UpdateGamePublisherAsync(UpdateGamePublisherDto dto)
    {
        var publisher = await _repository.GetByIdAsync(dto.GamePublisherId);
        if (publisher == null)
            throw new KeyNotFoundException("Game publisher not found.");

        _mapper.Map(dto, publisher);
        await _repository.UpdateAsync(publisher);
    }

    public async Task DeleteGamePublisherAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<GamePublisherDto?> GetGamePublisherByIdAsync(Guid id)
    {
        var publisher = await _repository.GetByIdAsync(id);
        return publisher == null ? null : _mapper.Map<GamePublisherDto>(publisher);
    }

    public async Task<List<GamePublisherDto>> GetAllGamePublishersAsync()
    {
        var publishers = await _repository.GetAllAsync();
        return _mapper.Map<List<GamePublisherDto>>(publishers);
    }

    public async Task<GamePublisherDto?> GetGamePublisherByNameAsync(string name)
    {
        var publishers = await _repository.GetFilteredItemsAsync(p => p.Name == name);
        return publishers.FirstOrDefault() == null ? null : _mapper.Map<GamePublisherDto>(publishers.First());
    }
}
