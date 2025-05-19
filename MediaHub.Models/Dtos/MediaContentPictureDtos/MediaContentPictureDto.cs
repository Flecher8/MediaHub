using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models.Dtos.PictureLinkDtos;
public class MediaContentPictureDto
{
    public required Guid PictureId { get; set; }
    public required string PictureLink { get; set; }
}
