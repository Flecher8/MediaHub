using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class Genre
{
    [Key]
    public Guid GenreId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //GenreEvaluation -> One to many
    public List<GenreEvaluation> GenreEvaluations { get; set; } = new();

    //MediaContent -> Many to many
    public List<MediaContent> MediaContents { get; set; } = new();

    #endregion
}
