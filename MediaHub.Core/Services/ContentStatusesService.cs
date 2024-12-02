using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.ContentStatusDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class ContentStatusesService : IContentStatusesService
{
    private readonly IContentStatusRepository _repository;
    private readonly IMapper _mapper;

    public ContentStatusesService(IContentStatusRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ContentStatusDto> CreateContentStatusAsync(CreateContentStatusDto dto)
    {
        var existingStatus = await _repository.GetFilteredItemsAsync(cs => cs.Name == dto.Name);
        if (existingStatus.Any())
        {
            throw new ArgumentException($"Content status with name '{dto.Name}' already exists.");
        }

        var status = _mapper.Map<ContentStatus>(dto);
        var createdStatus = await _repository.AddAsync(status);
        return _mapper.Map<ContentStatusDto>(createdStatus);
    }

    public async Task UpdateContentStatusAsync(UpdateContentStatusDto dto)
    {
        var status = await _repository.GetByIdAsync(dto.ContentStatusId);
        if (status == null)
            throw new KeyNotFoundException("Content status not found.");

        _mapper.Map(dto, status);
        await _repository.UpdateAsync(status);
    }

    public async Task DeleteContentStatusAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<ContentStatusDto?> GetContentStatusByIdAsync(Guid id)
    {
        var status = await _repository.GetByIdAsync(id);
        return status == null ? null : _mapper.Map<ContentStatusDto>(status);
    }

    public async Task<List<ContentStatusDto>> GetAllContentStatusesAsync()
    {
        var statuses = await _repository.GetAllAsync();
        return _mapper.Map<List<ContentStatusDto>>(statuses);
    }

    public async Task<ContentStatusDto?> GetContentStatusByNameAsync(string name)
    {
        var status = await _repository.GetFilteredItemsAsync(d => d.Name == name);
        return status.FirstOrDefault() == null ? null : _mapper.Map<ContentStatusDto>(status.First());
    }
}
