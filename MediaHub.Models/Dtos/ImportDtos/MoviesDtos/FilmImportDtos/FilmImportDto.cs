using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.MoviesDtos.FilmImportDtos;
public class FilmImportDto
{
    public string? Backdrop_Path { get; set; }
    public int Id { get; set; }
    public string Original_Title { get; set; } = "";
    public string? Overview { get; set; }
    public double Popularity { get; set; }
    public string? Poster_Path { get; set; }
    public string? Release_Date { get; set; }
    public int Runtime { get; set; }
    public double Vote_Average { get; set; }
    public List<SimpleDto> Genres { get; set; } = new();
    public CreditsDto Credits { get; set; } = new();
}
