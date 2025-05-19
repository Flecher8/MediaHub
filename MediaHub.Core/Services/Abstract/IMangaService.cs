using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MangaDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IMangaService
{
    Task<MangaDto?> GetByMediaContentIdAsync(Guid mediaContentId);
}
