using MediaHub.Models.Dtos.GameTagDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IGameTagsService
{
    Task<GameTagDto> CreateGameTagAsync(CreateGameTagDto dto);
    Task UpdateGameTagAsync(UpdateGameTagDto dto);
    Task DeleteGameTagAsync(Guid id);
    Task<GameTagDto?> GetGameTagByIdAsync(Guid id);
    Task<List<GameTagDto>> GetAllGameTagsAsync();
    Task<GameTagDto?> GetGameTagByNameAsync(string name);
}
