using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.FilmDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IFilmService
{
    Task<FilmDto?> GetByMediaContentIdAsync(Guid mediaContentId);
}
