using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.GameDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IGameService
{
    Task<GameDto?> GetByMediaContentIdAsync(Guid mediaContentId);
}
