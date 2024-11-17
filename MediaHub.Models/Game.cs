using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class Game
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public double MetacriticRating { get; set; }
    public double PlaytimeHours { get; set; }
    public double EsrbRating { get; set; }

    public List<GamePlatformGame> GamePlatformGames { get; set; } = new List<GamePlatformGame>();
    public List<GameDeveloperGame> GameDeveloperGames { get; set; } = new List<GameDeveloperGame>();
    public List<GamePublisherGame> GamePublisherGames { get; set; } = new List<GamePublisherGame>();
    public List<GameTagGame> GameTagGames { get; set; } = new List<GameTagGame>();
}
