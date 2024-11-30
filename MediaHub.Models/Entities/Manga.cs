namespace MediaHub.Models.Entities;

public class Manga
{
    public Guid MangaId { get; set; } = Guid.NewGuid();

    public int Rank { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfVolumes { get; set; }
    public int NumberOfChapters { get; set; }

    #region Foreign Keys

    //MediaContent -> One to one
    public Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //MangaAuthor -> Many to many
    public List<MangaAuthor> MangaAuthors { get; set; } = new();

    #endregion
}
