using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class GamePublisher
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public List<GamePublisherGame> GamePublisherGames { get; set; } = new List<GamePublisherGame>();
}
