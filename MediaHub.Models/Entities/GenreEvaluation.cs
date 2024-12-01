namespace MediaHub.Models.Entities;

public class GenreEvaluation
{
    public Guid GenreEvaluationId { get; set; } = Guid.NewGuid();

    public double Points { get; set; } = 0;

    #region Foreign Keys

    //RecommendationCollection -> Many to one
    public required Guid RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    //Genre -> Many to one
    public required Guid GenreId { get; set; }
    public Genre Genre { get; set; }

    #endregion
}
