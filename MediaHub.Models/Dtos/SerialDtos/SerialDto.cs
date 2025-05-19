using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MovieInfoDtos;

namespace MediaHub.Models.Dtos.SerialDtos;
public class SerialDto
{
    public required Guid SerialId { get; set; }
    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }

    // one-to-one
    public required MediaContentDto MediaContent { get; set; }

    // one-to-one
    public required MovieInfoDto MovieInfo { get; set; }
}
