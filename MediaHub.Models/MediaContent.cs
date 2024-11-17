using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class MediaContent
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 0;
    public DateTime ReleaseDate { get; set; }
    public string? MainPictureLink { get; set; }
    public List<MediaInteractionStatus> MediaInteractionStatuses { get; set; } = new List<MediaInteractionStatus>();
    public List<MediaContentGenre> MediaContentGenres { get; set; } = new List<MediaContentGenre>();
    public List<MediaContentPicture> MediaContentPictures { get; set; } = new List<MediaContentPicture>();

    public required string MediaContentTypeId { get; set; }
    public MediaContentType MediaContentType { get; set; }

    public Film? Film { get; set; }
    public Serial? Serial { get; set; }
    public Game? Game { get; set; }
    public Anime? Anime { get; set; }
    public Manga? Manga { get; set; }
}
