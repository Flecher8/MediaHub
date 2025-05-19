using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.ActorDtos;
using MediaHub.Models.Dtos.DirectorDtos;

namespace MediaHub.Models.Dtos.MovieInfoDtos;
public class MovieInfoDto
{
    public required Guid MovieInfoId { get; set; }
    public double DurationInMinutes { get; set; }

    // many-to-many
    public List<ActorDto> Actors { get; set; } = new();
    public List<DirectorDto> Directors { get; set; } = new();
}
