namespace MediaHub.Models.Entities;

public class Director
{
    public Guid DirectorId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //MovieInfo -> Many to many
    public List<MovieInfo> MovieInfos { get; set; } = new();

    #endregion
}
