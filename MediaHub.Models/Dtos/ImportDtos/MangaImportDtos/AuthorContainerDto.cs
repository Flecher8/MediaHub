using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.ImportDtos.MangaImportDtos;
public class AuthorContainerDto
{
    public AuthorNodeDto Node { get; set; } = new();
    public string? Role { get; set; }
}
