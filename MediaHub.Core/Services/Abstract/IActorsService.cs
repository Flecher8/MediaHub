using MediaHub.Models.Dtos.ActorDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IActorsService
{
    Task<ActorDto> CreateActorAsync(CreateActorDto dto);
    Task UpdateActorAsync(UpdateActorDto dto);
    Task DeleteActorAsync(Guid id);
    Task<ActorDto?> GetActorByIdAsync(Guid id);
    Task<List<ActorDto>> GetAllActorsAsync();
    Task<ActorDto?> GetActorByNameAsync(string name);
}
