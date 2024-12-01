namespace MediaHub.Models.Entities;

public class GamePublisher
{
    public Guid GamePublisherId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //Game -> Many to many
    public List<Game> Games { get; set; } = new();

    #endregion
}
