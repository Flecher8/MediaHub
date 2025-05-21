using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.EvaluationDtos;
public class EvaluationDto
{
    public Guid EvaluationId { get; set; }
    public string Name { get; set; } = null!;
}
