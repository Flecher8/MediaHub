using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class MangaAuthorManga
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string MangaId { get; set; }
    public Manga Manga { get; set; }

    public required string MangaAuthorId { get; set; }
    public MangaAuthor MangaAuthor { get; set; }
}
