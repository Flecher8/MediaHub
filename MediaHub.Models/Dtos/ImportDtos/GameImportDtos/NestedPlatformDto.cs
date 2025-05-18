using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.GameImportDtos;
public class NestedPlatformDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Slug { get; set; }
}
