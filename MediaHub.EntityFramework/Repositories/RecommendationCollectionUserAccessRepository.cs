using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class RecommendationCollectionUserAccessRepository : BaseFilterableRepository<RecommendationCollectionUserAccess>, IRecommendationCollectionUserAccessRepository
{
    // Constructor accepting the database context.
    public RecommendationCollectionUserAccessRepository(DataContext dbContext, BaseFilterBuilder<RecommendationCollectionUserAccess> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
