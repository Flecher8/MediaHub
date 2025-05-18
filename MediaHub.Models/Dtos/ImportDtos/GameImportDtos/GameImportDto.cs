using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.GameImportDtos;
public class GameImportDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Released { get; set; }
    public string? Background_Image { get; set; }
    public string? Background_Image_Additional { get; set; }
    public double Rating { get; set; }
    public double? Metacritic { get; set; }
    public int Playtime { get; set; }
    public string? Description { get; set; }
    public List<SimpleDto> Genres { get; set; } = new();
    public List<SimpleDto> Tags { get; set; } = new();
    public List<SimpleDto> Developers { get; set; } = new();
    public List<SimpleDto> Publishers { get; set; } = new();
    public List<PlatformContainerDto> Platforms { get; set; } = new();
    public List<PictureDto> Screenshots { get; set; } = new();
}
