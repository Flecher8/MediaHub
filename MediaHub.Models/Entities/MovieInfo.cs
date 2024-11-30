namespace MediaHub.Models.Entities;

public class MovieInfo
{
    public Guid MovieInfoId { get; set; } = Guid.NewGuid();

    public double DurationInMinutes { get; set; }

    #region Foreign Keys

    //Director -> Many to many
    public List<Director> Directors { get; set; } = new();

    //Actor -> Many to many
    public List<Actor> Actors { get; set; } = new();

    public Film? Film { get; set; }
    public Serial? Serial { get; set; }

    #endregion
}
