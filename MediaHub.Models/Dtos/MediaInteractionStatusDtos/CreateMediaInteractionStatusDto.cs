using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.MediaInteractionStatusDtos;
public class CreateMediaInteractionStatusDto
{
    [Required]
    public Guid MediaContentId { get; set; }

    [Required]
    public Guid RecommendationCollectionId { get; set; }
}
