using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.GenreDtos;
public class GenreDto
{
    public required Guid GenreId { get; set; }

    public required string Name { get; set; }
}
