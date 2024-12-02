using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MediaContentTypeDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class MediaContentTypesService : IMediaContentTypesService
{
    private readonly IMediaContentTypeRepository _repository;
    private readonly IMapper _mapper;

    public MediaContentTypesService(IMediaContentTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MediaContentTypeDto> CreateMediaContentTypeAsync(CreateMediaContentTypeDto dto)
    {
        var existingType = await _repository.GetFilteredItemsAsync(m => m.Name == dto.Name);
        if (existingType.Any())
        {
            throw new ArgumentException($"MediaContentType with name '{dto.Name}' already exists.");
        }

        var mediaContentType = _mapper.Map<MediaContentType>(dto);
        var createdType = await _repository.AddAsync(mediaContentType);
        return _mapper.Map<MediaContentTypeDto>(createdType);
    }

    public async Task UpdateMediaContentTypeAsync(UpdateMediaContentTypeDto dto)
    {
        var mediaContentType = await _repository.GetByIdAsync(dto.TypeId);
        if (mediaContentType == null)
        {
            throw new KeyNotFoundException("MediaContentType not found.");
        }

        _mapper.Map(dto, mediaContentType);
        await _repository.UpdateAsync(mediaContentType);
    }

    public async Task DeleteMediaContentTypeAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<MediaContentTypeDto?> GetMediaContentTypeByIdAsync(Guid id)
    {
        var mediaContentType = await _repository.GetByIdAsync(id);
        return mediaContentType == null ? null : _mapper.Map<MediaContentTypeDto>(mediaContentType);
    }

    public async Task<List<MediaContentTypeDto>> GetAllMediaContentTypesAsync()
    {
        var mediaContentTypes = await _repository.GetAllAsync();
        return _mapper.Map<List<MediaContentTypeDto>>(mediaContentTypes);
    }

    public async Task<MediaContentTypeDto?> GetMediaContentTypeByNameAsync(string name)
    {
        var mediaContentTypes = await _repository.GetFilteredItemsAsync(m => m.Name == name);
        return mediaContentTypes.FirstOrDefault() == null ? null : _mapper.Map<MediaContentTypeDto>(mediaContentTypes.First());
    }
}
