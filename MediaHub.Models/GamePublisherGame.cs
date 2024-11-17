using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class GamePublisherGame
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string GameId { get; set; }
    public Game Game { get; set; }

    public required string GamePublisherId { get; set; }
    public GamePublisher GamePublisher { get; set; }
}
