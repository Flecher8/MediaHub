using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Models.Dtos.RecommendationCollectionDtos;

namespace MediaHub.Core.Services.Abstract;
public interface IRecommendationCollectionsService
{
    Task<RecommendationCollectionDto> CreateCollectionAsync(CreateRecommendationCollectionDto dto);
    Task DeleteCollectionAsync(Guid collectionId);
    Task AddUserToCollectionAsync(AddUserToCollectionDto dto);
    Task RemoveUserFromCollectionAsync(Guid collectionId, Guid userId);
    Task<List<RecommendationCollectionDto>> GetUserCollectionsAsync(Guid userId);
}
