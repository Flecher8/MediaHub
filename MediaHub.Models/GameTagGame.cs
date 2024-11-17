using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class GameTagGame
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string GameId { get; set; }
    public Game Game { get; set; }

    public required string GameTagId { get; set; }
    public GameTag GameTag { get; set; }
}
