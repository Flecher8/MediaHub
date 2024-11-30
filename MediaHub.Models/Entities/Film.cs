namespace MediaHub.Models.Entities;

public class Film
{
    public Guid FilmId { get; set; } = Guid.NewGuid();

    #region Foreign Keys

    //MediaContent -> One to one
    public required Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //MovieInfo -> One to one
    public required Guid MovieInfoId { get; set; }
    public MovieInfo MovieInfo { get; set; }

    #endregion
}
