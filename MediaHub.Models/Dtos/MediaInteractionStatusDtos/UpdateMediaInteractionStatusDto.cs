using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.MediaInteractionStatusDtos;
public class UpdateMediaInteractionStatusDto
{
    public Guid MediaInteractionStatusId { get; set; }
    public Guid ContentStatusId { get; set; }
    public Guid EvaluationId { get; set; }
}
