namespace MediaHub.Models.Entities;

public class MediaContentType
{
    public Guid TypeId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //MediaContent -> Many to one
    public List<MediaContent> MediaContents { get; set; } = new();

    #endregion
}
