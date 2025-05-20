using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.RecommendationCollectionDtos;
public class AddUserToCollectionDto
{
    [Required]
    public Guid CollectionId { get; set; }

    [Required]
    [EmailAddress]
    public string UserEmail { get; set; } = null!;
}
