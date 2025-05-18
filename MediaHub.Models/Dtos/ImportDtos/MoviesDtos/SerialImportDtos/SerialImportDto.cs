using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.MoviesDtos.SerialImportDtos;
public class SerialImportDto
{
    public bool Adult { get; set; }
    public string? Backdrop_Path { get; set; }
    public string Name { get; set; } = "";
    public string? Overview { get; set; }
    public double Vote_Average { get; set; }
    public string? Poster_Path { get; set; }
    public string? First_Air_Date { get; set; }
    public int Number_Of_Seasons { get; set; }
    public int Number_Of_Episodes { get; set; }
    public List<SimpleDto> Genres { get; set; } = new();
    public CreditsDto Credits { get; set; } = new();
}
