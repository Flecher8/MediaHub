using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ActorDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class ActorsService : IActorsService
{
    private readonly IActorRepository _repository;
    private readonly IMapper _mapper;

    public ActorsService(IActorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ActorDto> CreateActorAsync(CreateActorDto dto)
    {
        var existingActor = await _repository.GetFilteredItemsAsync(a => a.Name == dto.Name);
        if (existingActor.Any())
        {
            throw new ArgumentException($"Actor with name '{dto.Name}' already exists.");
        }

        var actor = _mapper.Map<Actor>(dto);
        var createdActor = await _repository.AddAsync(actor);
        return _mapper.Map<ActorDto>(createdActor);
    }

    public async Task UpdateActorAsync(UpdateActorDto dto)
    {
        var actor = await _repository.GetByIdAsync(dto.ActorId);
        if (actor == null)
            throw new KeyNotFoundException("Actor not found.");

        _mapper.Map(dto, actor);
        await _repository.UpdateAsync(actor);
    }

    public async Task DeleteActorAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<ActorDto?> GetActorByIdAsync(Guid id)
    {
        var actor = await _repository.GetByIdAsync(id);
        return actor == null ? null : _mapper.Map<ActorDto>(actor);
    }

    public async Task<List<ActorDto>> GetAllActorsAsync()
    {
        var actors = await _repository.GetAllAsync();
        return _mapper.Map<List<ActorDto>>(actors);
    }

    public async Task<ActorDto?> GetActorByNameAsync(string name)
    {
        var actors = await _repository.GetFilteredItemsAsync(a => a.Name == name);
        return actors.FirstOrDefault() == null ? null : _mapper.Map<ActorDto>(actors.First());
    }
}
