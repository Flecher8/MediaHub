using MediaHub.Models.Dtos.MangaAuthorDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IMangaAuthorsService
{
    Task<MangaAuthorDto> CreateMangaAuthorAsync(CreateMangaAuthorDto dto);
    Task UpdateMangaAuthorAsync(UpdateMangaAuthorDto dto);
    Task DeleteMangaAuthorAsync(Guid id);
    Task<MangaAuthorDto?> GetMangaAuthorByIdAsync(Guid id);
    Task<List<MangaAuthorDto>> GetAllMangaAuthorsAsync();
    Task<MangaAuthorDto?> GetMangaAuthorByNameAsync(string name);
}
