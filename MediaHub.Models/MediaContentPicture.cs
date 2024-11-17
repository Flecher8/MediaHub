using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class MediaContentPicture
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string MediaContentId { get; set; }
    public MediaContent MediaContent { get; set; }

    public required string PictureLink { get; set; }
}
