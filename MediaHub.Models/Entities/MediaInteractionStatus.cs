using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class MediaInteractionStatus
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public required string ContentStatusId { get; set; }
    public ContentStatus ContentStatus { get; set; }

    public required string RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    public string? EvaluationId { get; set; }
    public Evaluation? Evaluation { get; set; }
}
