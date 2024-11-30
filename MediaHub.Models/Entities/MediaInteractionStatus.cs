using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class MediaInteractionStatus
{
    [Key]
    public Guid MediaInteractionStatusId { get; set; } = Guid.NewGuid();

    #region Foreign Keys

    //MediaContent -> One to many
    public required Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //ContentStatus -> Many to one
    public required Guid ContentStatusId { get; set; }
    public ContentStatus ContentStatus { get; set; }

    //RecommendationCollection -> Many to one
    public required Guid RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    //Evaluation -> Many to one
    public Guid? EvaluationId { get; set; }
    public Evaluation? Evaluation { get; set; }

    #endregion
}
