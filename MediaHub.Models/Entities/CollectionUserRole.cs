namespace MediaHub.Models.Entities;

public class CollectionUserRole
{
    public Guid CollectionUserRoleId { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    #region Foreign Keys

    //RecommendationCollectionUserAccess -> One to many
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; } = new ();

    #endregion
}
