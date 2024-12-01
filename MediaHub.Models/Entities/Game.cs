namespace MediaHub.Models.Entities;

public class Game
{
    public Guid GameId { get; set; } = Guid.NewGuid();

    public double MetacriticRating { get; set; }
    public double PlaytimeHours { get; set; }
    public double EsrbRating { get; set; }

    #region Foreign Keys

    //MediaContent -> One to one
    public Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //Many to many
    public List<GamePlatform> GamePlatforms { get; set; } = new();
    public List<GameDeveloper> GameDevelopers { get; set; } = new();
    public List<GamePublisher> GamePublishers { get; set; } = new();
    public List<GameTag> GameTags { get; set; } = new();

    #endregion
}
