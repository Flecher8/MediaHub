namespace MediaHub.Models.Entities;

public class AnimeStudio
{
    public Guid AnimeStudioId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //Anime -> Many to many
    public List<Anime> Animes { get; set; } = new();

    #endregion
}
