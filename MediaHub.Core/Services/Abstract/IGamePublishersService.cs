using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.GamePublisherDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IGamePublishersService
{
    Task<GamePublisherDto> CreateGamePublisherAsync(CreateGamePublisherDto dto);
    Task UpdateGamePublisherAsync(UpdateGamePublisherDto dto);
    Task DeleteGamePublisherAsync(Guid id);
    Task<GamePublisherDto?> GetGamePublisherByIdAsync(Guid id);
    Task<List<GamePublisherDto>> GetAllGamePublishersAsync();
    Task<GamePublisherDto?> GetGamePublisherByNameAsync(string name);
}
