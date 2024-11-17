using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class RecommendationCollection
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string CreatorId { get; set; }
    public User Creator { get; set; }
    public List<MediaInteractionStatus> MediaInteractionStatus { get; set; } = new List<MediaInteractionStatus>();
    public List<GenreEvaluation> GenreEvaluations { get; set; } = new List<GenreEvaluation>();
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; } = new List<RecommendationCollectionUserAccess>();
}
