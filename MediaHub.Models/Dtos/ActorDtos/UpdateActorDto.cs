using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Dtos.ActorDtos;
public class UpdateActorDto
{
    [Required(ErrorMessage = "Id is required.")]
    public required Guid ActorId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public required string Name { get; set; }
}
