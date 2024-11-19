﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class GamePlatform
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }

    public List<Game> Games { get; set; } = new List<Game>();
}
