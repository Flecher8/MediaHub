using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.GameDeveloperDtos;
using MediaHub.Models.Dtos.GamePlatformDtos;
using MediaHub.Models.Dtos.GamePublisherDtos;
using MediaHub.Models.Dtos.GameTagDtos;
using MediaHub.Models.Dtos.MediaContentDtos;

namespace MediaHub.Models.Dtos.GameDtos;
public class GameDto
{
    public Guid GameId { get; set; }
    public double MetacriticRating { get; set; }
    public double PlaytimeHours { get; set; }
    public double EsrbRating { get; set; }

    // one-to-one
    public required MediaContentDto MediaContent { get; set; }

    // many-to-many
    public List<GamePlatformDto> GamePlatforms { get; set; } = new();
    public List<GameDeveloperDto> GameDevelopers { get; set; } = new();
    public List<GamePublisherDto> GamePublishers { get; set; } = new();
    public List<GameTagDto> GameTags { get; set; } = new();
}
