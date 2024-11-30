using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class MediaContentPicture
{
    [Key]
    public Guid PictureId { get; set; } = Guid.NewGuid();

    public required string PictureLink { get; set; }

    #region Foreign Keys

    //MediaContent -> One to one
    public required Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    #endregion
}
