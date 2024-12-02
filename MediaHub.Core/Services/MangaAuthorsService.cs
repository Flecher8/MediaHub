using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MangaAuthorDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class MangaAuthorsService : IMangaAuthorsService
{
    private readonly IMangaAuthorRepository _repository;
    private readonly IMapper _mapper;

    public MangaAuthorsService(IMangaAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MangaAuthorDto> CreateMangaAuthorAsync(CreateMangaAuthorDto dto)
    {
        var existingAuthor = await _repository.GetFilteredItemsAsync(a => a.Name == dto.Name);
        if (existingAuthor.Any())
        {
            throw new ArgumentException($"Manga author with name '{dto.Name}' already exists.");
        }

        var author = _mapper.Map<MangaAuthor>(dto);
        var createdAuthor = await _repository.AddAsync(author);
        return _mapper.Map<MangaAuthorDto>(createdAuthor);
    }

    public async Task UpdateMangaAuthorAsync(UpdateMangaAuthorDto dto)
    {
        var author = await _repository.GetByIdAsync(dto.MangaAuthorId);
        if (author == null)
            throw new KeyNotFoundException("Manga author not found.");

        _mapper.Map(dto, author);
        await _repository.UpdateAsync(author);
    }

    public async Task DeleteMangaAuthorAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<MangaAuthorDto?> GetMangaAuthorByIdAsync(Guid id)
    {
        var author = await _repository.GetByIdAsync(id);
        return author == null ? null : _mapper.Map<MangaAuthorDto>(author);
    }

    public async Task<List<MangaAuthorDto>> GetAllMangaAuthorsAsync()
    {
        var authors = await _repository.GetAllAsync();
        return _mapper.Map<List<MangaAuthorDto>>(authors);
    }

    public async Task<MangaAuthorDto?> GetMangaAuthorByNameAsync(string name)
    {
        var authors = await _repository.GetFilteredItemsAsync(a => a.Name == name);
        return authors.FirstOrDefault() == null ? null : _mapper.Map<MangaAuthorDto>(authors.First());
    }
}
