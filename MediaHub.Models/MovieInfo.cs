using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class MovieInfo
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public double DurationInMinutes { get; set; }

    public Film? Film { get; set; }
    public Serial? Serial { get; set; }

    public List<DirectorMovieInfo> DirectorMovieInfos { get; set; } = new List<DirectorMovieInfo>();
    public List<ActorMovieInfo> ActorMovieInfos { get; set; } = new List<ActorMovieInfo>();
}
