﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class MangaAuthor
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }

    public List<Manga> Mangas { get; set; } = new List<Manga>();
}
