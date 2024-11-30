using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class RecommendationCollectionRepository : BaseFilterableRepository<RecommendationCollection>, IRecommendationCollectionRepository
{
    // Constructor accepting the database context.
    public RecommendationCollectionRepository(DataContext dbContext, BaseFilterBuilder<RecommendationCollection> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
