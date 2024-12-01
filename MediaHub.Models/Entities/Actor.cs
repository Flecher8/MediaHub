namespace MediaHub.Models.Entities;

public class Actor
{
    public Guid ActorId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //MovieInfo -> Many to many
    public List<MovieInfo> MovieInfos { get; set; } = new ();

    #endregion
}
