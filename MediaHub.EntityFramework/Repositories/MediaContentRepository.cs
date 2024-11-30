using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class MediaContentRepository : BaseFilterableRepository<MediaContent>, IMediaContentRepository
{
    // Constructor accepting the database context.
    public MediaContentRepository(DataContext dbContext, BaseFilterBuilder<MediaContent> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
