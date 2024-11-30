namespace MediaHub.Models.Entities;

public class GameDeveloper
{
    public Guid GameDeveloperId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //Game -> Many to many
    public List<Game> Games { get; set; } = new();

    #endregion
}
