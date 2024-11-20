using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class Serial
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public required string MovieInfoId { get; set; }
    public MovieInfo MovieInfo { get; set; }

    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }
}
