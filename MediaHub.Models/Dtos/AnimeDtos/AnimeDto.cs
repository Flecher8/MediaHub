using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.AnimeStudioDtos;
using MediaHub.Models.Dtos.MediaContentDtos;

namespace MediaHub.Models.Dtos.AnimeDtos;
public class AnimeDto
{
    public required Guid AnimeId { get; set; }
    public int Rank { get; set; }
    public int NumberOfEpisodes { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // nested media content
    public required MediaContentDto MediaContent { get; set; }

    // all related studios
    public List<AnimeStudioDto> AnimeStudios { get; set; } = new();
}
