namespace MediaHub.Models.Entities;

public class Serial
{
    public Guid SerialId { get; set; } = Guid.NewGuid();

    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }

    #region Foreign Keys

    //MediaContent -> One to one
    public required Guid MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    //MovieInfo -> One to one
    public required Guid MovieInfoId { get; set; }
    public MovieInfo MovieInfo { get; set; }

    #endregion
}
