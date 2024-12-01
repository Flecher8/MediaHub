namespace MediaHub.Models.Entities;

public class GameTag
{
    public Guid GameTagId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //Game -> Many to many
    public List<Game> Games { get; set; } = new();

    #endregion
}
