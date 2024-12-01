using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.GamePlatformDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IGamePlatformsService
{
    Task<GamePlatformDto> CreateGamePlatformAsync(CreateGamePlatformDto dto);
    Task UpdateGamePlatformAsync(UpdateGamePlatformDto dto);
    Task DeleteGamePlatformAsync(Guid id);
    Task<GamePlatformDto?> GetGamePlatformByIdAsync(Guid id);
    Task<List<GamePlatformDto>> GetAllGamePlatformsAsync();
    Task<GamePlatformDto?> GetGamePlatformByNameAsync(string name);
}
