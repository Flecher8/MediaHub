using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;

public class MediaContentsService : IMediaContentsService
{
    private readonly IMediaContentRepository _repository;
    private readonly IMapper _mapper;

    public MediaContentsService(IMediaContentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MediaContentDto> CreateMediaContentAsync(CreateMediaContentDto dto)
    {
        var existingMediaContents = await _repository.GetFilteredItemsAsync(m => m.Title == dto.Title);
        if (existingMediaContents.Any())
        {
            throw new ArgumentException($"MediaContent with name '{dto.Title}' already exists.");
        }

        var mediaContent = _mapper.Map<MediaContent>(dto);
        var createdMediaContent = await _repository.AddAsync(mediaContent);
        return _mapper.Map<MediaContentDto>(createdMediaContent);
    }

    public async Task UpdateMediaContentAsync(UpdateMediaContentDto dto)
    {
        var mediaContent = await _repository.GetByIdAsync(dto.UpdateMediaContentId);
        if (mediaContent == null)
        {
            throw new KeyNotFoundException("MediaContent not found.");
        }

        _mapper.Map(dto, mediaContent);
        await _repository.UpdateAsync(mediaContent);
    }

    public async Task DeleteMediaContentAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<MediaContentDto?> GetMediaContentByIdAsync(Guid id)
    {
        var mediaContent = await _repository.GetByIdAsync(id);
        return mediaContent == null ? null : _mapper.Map<MediaContentDto>(mediaContent);
    }

    public async Task<List<MediaContentDto>> GetAllMediaContentsAsync()
    {
        var mediaContents = await _repository.GetAllAsync();
        return _mapper.Map<List<MediaContentDto>>(mediaContents);
    }

    public async Task<MediaContentDto?> GetMediaContentByTitleAsync(string title)
    {
        var mediaContents = await _repository.GetFilteredItemsAsync(m => m.Title == title);
        return mediaContents.FirstOrDefault() == null ? null : _mapper.Map<MediaContentDto>(mediaContents.First());
    }
}
