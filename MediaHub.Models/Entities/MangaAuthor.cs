namespace MediaHub.Models.Entities;

public class MangaAuthor
{
    public Guid MangaAuthorId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //Manga -> Many to many
    public List<Manga> Mangas { get; set; } = new();

    #endregion
}
