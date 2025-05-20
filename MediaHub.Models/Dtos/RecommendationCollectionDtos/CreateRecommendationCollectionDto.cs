using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.RecommendationCollectionDtos;
public class CreateRecommendationCollectionDto
{
    [Required]
    public Guid CreatorUserId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;
}
