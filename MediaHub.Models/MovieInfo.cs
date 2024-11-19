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

    public List<Director> Directors { get; set; } = new List<Director>();

    public List<Actor> Actors { get; set; } = new List<Actor>();
}
