using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class Genre
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public List<GenreEvaluation> GenreEvaluations { get; set; } = new List<GenreEvaluation>();

    public List<MediaContent> MediaContents { get; set; } = new List<MediaContent>();
}
