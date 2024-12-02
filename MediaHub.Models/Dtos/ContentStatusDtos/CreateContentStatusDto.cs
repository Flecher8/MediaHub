using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Dtos.ContentStatusDtos;
public class CreateContentStatusDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public required string Name { get; set; }
}
