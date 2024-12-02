using MediaHub.Models.Dtos.MediaContentTypeDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IMediaContentTypesService
{
    Task<MediaContentTypeDto> CreateMediaContentTypeAsync(CreateMediaContentTypeDto dto);
    Task UpdateMediaContentTypeAsync(UpdateMediaContentTypeDto dto);
    Task DeleteMediaContentTypeAsync(Guid id);
    Task<MediaContentTypeDto?> GetMediaContentTypeByIdAsync(Guid id);
    Task<List<MediaContentTypeDto>> GetAllMediaContentTypesAsync();
    Task<MediaContentTypeDto?> GetMediaContentTypeByNameAsync(string name);
}
