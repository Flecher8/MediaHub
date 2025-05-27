using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.MediaContentDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IRecommendationsService
{
    Task<List<MediaContentDto>> GetRecommendationsAsync(Guid collectionId, int page = 1, int pageSize = 100);
    Task<List<MediaContentDto>> GetRecommendationsForGuestAsync(int page = 1, int pageSize = 100);
    Task<int> GetRecommendationsPageCountAsync(Guid collectionId, int pageSize = 100);
    Task<int> GetRecommendationsForGuestPageCountAsync(int pageSize = 100);
}
