using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.AnimeImportDtos;
public class AnimeImportDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public MainPictureDto? Main_Picture { get; set; }
    public string Synopsis { get; set; } = "";
    public double Mean { get; set; }
    public int Rank { get; set; }
    public int Num_Episodes { get; set; }
    public string? Start_Date { get; set; }
    public string? End_Date { get; set; }
    public List<SimpleDto> Genres { get; set; } = new();
    public List<PictureDto> Pictures { get; set; } = new();
    public List<StudioDto> Studios { get; set; } = new();
}
