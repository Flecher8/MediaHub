using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.MoviesDtos;
public class CreditsDto
{
    public List<CastDto> Cast { get; set; } = new();
    public List<CrewDto> Crew { get; set; } = new();
}
