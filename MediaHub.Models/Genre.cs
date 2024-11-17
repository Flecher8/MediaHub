using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class Genre
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public List<GenreEvaluation> GenreEvaluations { get; set; } = new List<GenreEvaluation>();
    public List<MediaContentGenre> MediaContentGenres { get; set; } = new List<MediaContentGenre>();
}
