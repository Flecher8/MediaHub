using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Dtos.MediaContentDtos;

public class CreateMediaContentDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200, ErrorMessage = "Title must not exceed 200 characters.")]
    public required string Title { get; set; }

    [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0 and 10.")]
    public double? Rating { get; set; }

    [MaxLength(10000, ErrorMessage = "Description must not exceed 10000 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Release date is required.")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1/1/1900", "12/31/2099", ErrorMessage = "Release date must be between 01/01/1900 and 12/31/2099.")]
    public required DateTime ReleaseDate { get; set; }

    [MaxLength(500, ErrorMessage = "MainPictureLink must not exceed 500 characters.")]
    [Url(ErrorMessage = "MainPictureLink must be a valid URL.")]
    public string? MainPictureLink { get; set; }
}
