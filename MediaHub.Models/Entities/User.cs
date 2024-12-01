using Microsoft.AspNetCore.Identity;

namespace MediaHub.Models.Entities;

[Serializable]
public class User : IdentityUser<Guid>
{
    //PK: public Guid Id { get; set; }

    #region Foreign Keys

    //RecommendationCollection -> One to many
    public List<RecommendationCollection> RecommendationCollections { get; set; } = new();

    //RecommendationCollectionUserAccess -> One to many
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccess { get; set; } = new();

    #endregion
}
