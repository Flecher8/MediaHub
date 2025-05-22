using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.EvaluationDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IEvaluationService
{
    Task<List<EvaluationDto>> GetAllAsync();
}
