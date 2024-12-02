using MediaHub.Models.Dtos.DirectorDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IDirectorsService
{
    Task<DirectorDto> CreateDirectorAsync(CreateDirectorDto dto);
    Task UpdateDirectorAsync(UpdateDirectorDto dto);
    Task DeleteDirectorAsync(Guid id);
    Task<DirectorDto?> GetDirectorByIdAsync(Guid id);
    Task<List<DirectorDto>> GetAllDirectorsAsync();
    Task<DirectorDto?> GetDirectorByNameAsync(string name);
}
