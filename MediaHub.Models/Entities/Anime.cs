namespace MediaHub.Models.Entities;

public class Anime
{
    public Guid AnimeId { get; set; } = Guid.NewGuid();

    public int Rank { get; set; }
    public int NumberOfEpisodes { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    #region Foreign Keys

    //MediaContent -> One to one
    public Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //AnimeStudio -> Many to many
    public List<AnimeStudio> AnimeStudios { get; set; } = new ();

    #endregion
}
