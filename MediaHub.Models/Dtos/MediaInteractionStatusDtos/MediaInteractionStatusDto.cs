using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.ContentStatusDtos;
using MediaHub.Models.Dtos.EvaluationDtos;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.RecommendationCollectionDtos;

namespace MediaHub.Models.Dtos.MediaInteractionStatusDtos;
public class MediaInteractionStatusDto
{
    public Guid MediaInteractionStatusId { get; set; }
    public MediaContentDto MediaContent { get; set; } = null!;
    public ContentStatusDto ContentStatus { get; set; } = null!;
    public RecommendationCollectionDto RecommendationCollection { get; set; } = null!;
    public EvaluationDto? Evaluation { get; set; } = null!;
}
