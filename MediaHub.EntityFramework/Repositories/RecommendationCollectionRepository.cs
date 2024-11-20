using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class RecommendationCollectionRepository : BaseFilterableRepository<RecommendationCollection>, IRecommendationCollectionRepository
{
    // Constructor accepting the database context.
    public RecommendationCollectionRepository(DataContext dbContext, BaseFilterBuilder<RecommendationCollection> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
