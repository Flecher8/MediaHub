using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class MediaContent
{
    [Key]
    public Guid MediaContentId { get; set; } = Guid.NewGuid();

    #region Params

    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 0;
    public DateTime ReleaseDate { get; set; }
    public string? MainPictureLink { get; set; }

    #endregion

    #region Foreign Keys

    //MediaInteractionStatus -> Many to one
    public List<MediaInteractionStatus> MediaInteractionStatuses { get; set; } = new();

    //MediaContentPicture -> Many to one
    public List<MediaContentPicture> MediaContentPictures { get; set; } = new();

    //Genre -> Many to many
    public List<Genre> Genres { get; set; } = new();

    //MediaContentType -> One to many
    public required Guid MediaContentTypeId { get; set; }
    public MediaContentType MediaContentType { get; set; }

    public Film? Film { get; set; }
    public Serial? Serial { get; set; }
    public Game? Game { get; set; }
    public Anime? Anime { get; set; }
    public Manga? Manga { get; set; }

    #endregion
}
