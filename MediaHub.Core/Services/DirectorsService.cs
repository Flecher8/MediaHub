using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.DirectorDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class DirectorsService : IDirectorsService
{
    private readonly IDirectorRepository _repository;
    private readonly IMapper _mapper;

    public DirectorsService(IDirectorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DirectorDto> CreateDirectorAsync(CreateDirectorDto dto)
    {
        var existingDirector = await _repository.GetFilteredItemsAsync(d => d.Name == dto.Name);
        if (existingDirector.Any())
        {
            throw new ArgumentException($"Director with name '{dto.Name}' already exists.");
        }

        var director = _mapper.Map<Director>(dto);
        var createdDirector = await _repository.AddAsync(director);
        return _mapper.Map<DirectorDto>(createdDirector);
    }

    public async Task UpdateDirectorAsync(UpdateDirectorDto dto)
    {
        var director = await _repository.GetByIdAsync(dto.DirectorId);
        if (director == null)
            throw new KeyNotFoundException("Director not found.");

        _mapper.Map(dto, director);
        await _repository.UpdateAsync(director);
    }

    public async Task DeleteDirectorAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<DirectorDto?> GetDirectorByIdAsync(Guid id)
    {
        var director = await _repository.GetByIdAsync(id);
        return director == null ? null : _mapper.Map<DirectorDto>(director);
    }

    public async Task<List<DirectorDto>> GetAllDirectorsAsync()
    {
        var directors = await _repository.GetAllAsync();
        return _mapper.Map<List<DirectorDto>>(directors);
    }

    public async Task<DirectorDto?> GetDirectorByNameAsync(string name)
    {
        var directors = await _repository.GetFilteredItemsAsync(d => d.Name == name);
        return directors.FirstOrDefault() == null ? null : _mapper.Map<DirectorDto>(directors.First());
    }
}
