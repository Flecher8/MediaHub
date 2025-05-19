using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MovieInfoDtos;

namespace MediaHub.Models.Dtos.FilmDtos;
public class FilmDto
{
    public required Guid FilmId { get; set; }

    // one-to-one
    public required MediaContentDto MediaContent { get; set; }

    // one-to-one
    public required MovieInfoDto MovieInfo { get; set; }
}
