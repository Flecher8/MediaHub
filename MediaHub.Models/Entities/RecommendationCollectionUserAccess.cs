using System.ComponentModel.DataAnnotations;

namespace MediaHub.Models.Entities;

public class RecommendationCollectionUserAccess
{
    [Key]
    public Guid UserAccessId { get; set; } = Guid.NewGuid();

    #region Foreign Keys

    //User -> Many to one
    public required Guid UserId { get; set; }
    public User User { get; set; }

    //RecommendationCollection -> Many to one
    public required Guid RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    //CollectionUserRole -> Many to one
    public required Guid CollectionUserRoleId { get; set; }
    public CollectionUserRole CollectionUserRole { get; set; }

    #endregion
}
