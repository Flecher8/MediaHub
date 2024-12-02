using MediaHub.Models.Dtos.AnimeStudioDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IAnimeStudiosService
{
    Task<AnimeStudioDto> CreateAnimeStudioAsync(CreateAnimeStudioDto dto);
    Task UpdateAnimeStudioAsync(UpdateAnimeStudioDto dto);
    Task DeleteAnimeStudioAsync(Guid id);
    Task<AnimeStudioDto?> GetAnimeStudioByIdAsync(Guid id);
    Task<List<AnimeStudioDto>> GetAllAnimeStudiosAsync();
    Task<AnimeStudioDto?> GetAnimeStudioByNameAsync(string name);
}
