using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MangaAuthorDtos;
using MediaHub.Models.Dtos.MediaContentDtos;

namespace MediaHub.Models.Dtos.MangaDtos;
public class MangaDto
{
    public required Guid MangaId { get; set; }
    public int Rank { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfVolumes { get; set; }
    public int NumberOfChapters { get; set; }

    // the one-to-one media content
    public required MediaContentDto MediaContent { get; set; }

    // many-to-many authors
    public List<MangaAuthorDto> MangaAuthors { get; set; } = new();
}
