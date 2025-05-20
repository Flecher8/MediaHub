using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.CollectionUserRoleDtos;
using MediaHub.Models.Dtos.UserDtos;

namespace MediaHub.Models.Dtos.RecommendationCollectionUserAccessDtos;
public class RecommendationCollectionUserAccessDto
{
    public Guid UserAccessId { get; set; }
    public UserDto User { get; set; } = null!;
    public CollectionUserRoleDto Role { get; set; } = null!;
}
