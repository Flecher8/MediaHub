using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class Anime
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public int Rank { get; set; }
    public int NumberOfEpisodes { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<AnimeStudio> AnimeStudios { get; set; } = new List<AnimeStudio>();
}
