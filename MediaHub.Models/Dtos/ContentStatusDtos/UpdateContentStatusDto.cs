using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Dtos.ContentStatusDtos;
public class UpdateContentStatusDto
{
    [Required(ErrorMessage = "Id is required.")]
    public required Guid ContentStatusId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public required string Name { get; set; }
}
