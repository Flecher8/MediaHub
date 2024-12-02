using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.AnimeStudioDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class AnimeStudiosService : IAnimeStudiosService
{
    private readonly IAnimeStudioRepository _repository;
    private readonly IMapper _mapper;

    public AnimeStudiosService(IAnimeStudioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AnimeStudioDto> CreateAnimeStudioAsync(CreateAnimeStudioDto dto)
    {
        var existingStudio = await _repository.GetFilteredItemsAsync(s => s.Name == dto.Name);
        if (existingStudio.Any())
        {
            throw new ArgumentException($"Anime studio with name '{dto.Name}' already exists.");
        }

        var studio = _mapper.Map<AnimeStudio>(dto);
        var createdStudio = await _repository.AddAsync(studio);
        return _mapper.Map<AnimeStudioDto>(createdStudio);
    }

    public async Task UpdateAnimeStudioAsync(UpdateAnimeStudioDto dto)
    {
        var studio = await _repository.GetByIdAsync(dto.AnimeStudioId);
        if (studio == null)
            throw new KeyNotFoundException("Anime studio not found.");

        _mapper.Map(dto, studio);
        await _repository.UpdateAsync(studio);
    }

    public async Task DeleteAnimeStudioAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<AnimeStudioDto?> GetAnimeStudioByIdAsync(Guid id)
    {
        var studio = await _repository.GetByIdAsync(id);
        return studio == null ? null : _mapper.Map<AnimeStudioDto>(studio);
    }

    public async Task<List<AnimeStudioDto>> GetAllAnimeStudiosAsync()
    {
        var studios = await _repository.GetAllAsync();
        return _mapper.Map<List<AnimeStudioDto>>(studios);
    }

    public async Task<AnimeStudioDto?> GetAnimeStudioByNameAsync(string name)
    {
        var studios = await _repository.GetFilteredItemsAsync(s => s.Name == name);
        return studios.FirstOrDefault() == null ? null : _mapper.Map<AnimeStudioDto>(studios.First());
    }
}
