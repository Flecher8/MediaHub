using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class RecommendationCollectionUserAccess
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string UserId { get; set; }
    public User User { get; set; }

    public required string RecommendationCollectionId { get; set; }
    public RecommendationCollection RecommendationCollection { get; set; }

    public required string CollectionUserRoleId { get; set; }
    public CollectionUserRole CollectionUserRole { get; set; }
}
