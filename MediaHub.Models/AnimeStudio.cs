﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class AnimeStudio
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }

    public List<Anime> Animes { get; set; } = new List<Anime>();
}
