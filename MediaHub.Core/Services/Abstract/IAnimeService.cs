using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.AnimeDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IAnimeService
{
    Task<AnimeDto?> GetByMediaContentIdAsync(Guid mediaContentId);
}
