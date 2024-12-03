using MediaHub.Models.Dtos.MediaContentDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IMediaContentsService
{
    Task<MediaContentDto> CreateMediaContentAsync(CreateMediaContentDto dto);
    Task UpdateMediaContentAsync(UpdateMediaContentDto dto);
    Task DeleteMediaContentAsync(Guid id);
    Task<MediaContentDto?> GetMediaContentByIdAsync(Guid id);
    Task<List<MediaContentDto>> GetAllMediaContentsAsync();
    Task<MediaContentDto?> GetMediaContentByTitleAsync(string title);
}
