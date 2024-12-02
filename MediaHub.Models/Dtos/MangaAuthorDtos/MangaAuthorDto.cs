using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Dtos.MangaAuthorDtos;
public class MangaAuthorDto
{
    [Required(ErrorMessage = "Id is required.")]
    public required Guid MangaAuthorId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
    public required string Name { get; set; }
}
