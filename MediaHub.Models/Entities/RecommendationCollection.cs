using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

[Serializable]
public class RecommendationCollection
{
    [Key]
    public Guid CollectionId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //User -> Many to one
    public required Guid CreatorUserId { get; set; }
    public User CreatorUser { get; set; }

    //MediaInteractionStatus -> One to many
    public List<MediaInteractionStatus> MediaInteractionStatus { get; set; } = new();

    //GenreEvaluation -> One to many
    public List<GenreEvaluation> GenreEvaluations { get; set; } = new();

    //RecommendationCollectionUserAccess -> One to many
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; } = new();

    #endregion
}
