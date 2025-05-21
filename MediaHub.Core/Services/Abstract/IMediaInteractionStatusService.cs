using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MediaInteractionStatusDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IMediaInteractionStatusService
{
    Task<MediaInteractionStatusDto> AddAsync(CreateMediaInteractionStatusDto dto);
    Task<MediaInteractionStatusDto> UpdateAsync(UpdateMediaInteractionStatusDto dto);
    Task DeleteAsync(Guid mediaInteractionStatusId);
    Task<MediaInteractionStatusDto?> GetByIdAsync(Guid id);
    Task<List<MediaContentDto>> GetMediaByCollectionAsync(Guid recommendationCollectionId);
    Task DeleteByCollectionAndMediaAsync(Guid recommendationCollectionId, Guid mediaContentId);
}
