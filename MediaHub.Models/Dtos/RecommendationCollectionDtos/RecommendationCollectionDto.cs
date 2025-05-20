using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.RecommendationCollectionUserAccessDtos;
using MediaHub.Models.Dtos.UserDtos;

namespace MediaHub.Models.Dtos.RecommendationCollectionDtos;
public class RecommendationCollectionDto
{
    public Guid CollectionId { get; set; }
    public string Name { get; set; } = null!;
    public UserDto Creator { get; set; } = null!;

    public List<RecommendationCollectionUserAccessDto> RecommendationCollectionUserAccesses { get; set; } = new();
}
