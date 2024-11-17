using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class DirectorMovieInfo
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string MovieInfoId { get; set; }
    public MovieInfo MovieInfo { get; set; }

    public required string DirectorId { get; set; }
    public Director Director { get; set; }
}
