using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Entities;
public class Game
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public double MetacriticRating { get; set; }
    public double PlaytimeHours { get; set; }
    public double EsrbRating { get; set; }

    public List<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
    public List<GameDeveloper> GameDevelopers { get; set; } = new List<GameDeveloper>();
    public List<GamePublisher> GamePublishers { get; set; } = new List<GamePublisher>();
    public List<GameTag> GameTags { get; set; } = new List<GameTag>();
}
