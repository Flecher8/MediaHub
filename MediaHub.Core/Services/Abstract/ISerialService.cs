using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.SerialDtos;

namespace MediaHub.Core.Services.Abstract;
public interface ISerialService
{
    Task<SerialDto?> GetByMediaContentIdAsync(Guid mediaContentId);
}
