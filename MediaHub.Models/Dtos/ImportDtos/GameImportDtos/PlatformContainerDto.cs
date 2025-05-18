using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.GameImportDtos;
public class PlatformContainerDto
{
    public NestedPlatformDto Platform { get; set; } = new();
}
