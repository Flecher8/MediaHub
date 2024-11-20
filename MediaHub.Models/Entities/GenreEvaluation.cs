using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class GenreEvaluation
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    public required string GenreId { get; set; }
    public Genre Genre { get; set; }

    public double Points { get; set; } = 0;
}
