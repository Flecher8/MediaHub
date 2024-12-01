using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.GameDeveloperDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IGameDevelopersService
{
    Task<GameDeveloperDto> CreateGameDeveloperAsync(CreateGameDeveloperDto dto);
    Task UpdateGameDeveloperAsync(UpdateGameDeveloperDto dto);
    Task DeleteGameDeveloperAsync(Guid id);
    Task<GameDeveloperDto?> GetGameDeveloperByIdAsync(Guid id);
    Task<List<GameDeveloperDto>> GetAllGameDevelopersAsync();
    Task<GameDeveloperDto?> GetGameDeveloperByNameAsync(string name);
}
