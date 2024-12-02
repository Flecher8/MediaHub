using MediaHub.Models.Dtos.ContentStatusDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IContentStatusesService
{
    Task<ContentStatusDto> CreateContentStatusAsync(CreateContentStatusDto dto);
    Task UpdateContentStatusAsync(UpdateContentStatusDto dto);
    Task DeleteContentStatusAsync(Guid id);
    Task<ContentStatusDto?> GetContentStatusByIdAsync(Guid id);
    Task<List<ContentStatusDto>> GetAllContentStatusesAsync();
    Task<ContentStatusDto?> GetContentStatusByNameAsync(string name);
}
