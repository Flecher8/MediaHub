using Microsoft.AspNetCore.Identity;

namespace MediaHub.Models.Entities;

[Serializable]
public class User : IdentityUser<Guid>
{
    //PK: public Guid Id { get; set; }

    #region Foreign Keys

    //UserRole -> Many to one
    public Guid UserRoleId { get; set; }
    public UserRole UserRole { get; set; }

    //RecommendationCollection -> One to many
    public List<RecommendationCollection> RecommendationCollections { get; set; } = new();

    //RecommendationCollectionUserAccess -> One to many
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccess { get; set; } = new();

    #endregion
}
