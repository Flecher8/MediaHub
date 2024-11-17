using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class Manga
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public int Rank { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfVolumes { get; set; } = 0;
    public int NumberOfChapters { get; set; } = 0;

    public List<MangaAuthorManga> MangaAuthorMangas { get; set; } = new List<MangaAuthorManga>();
}
