using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.CollectionUserRoleDtos;
public class CollectionUserRoleDto
{
    public Guid CollectionUserRoleId { get; set; }
    public string Name { get; set; } = null!;
}
