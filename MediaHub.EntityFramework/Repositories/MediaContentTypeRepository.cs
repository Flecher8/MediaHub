using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class MediaContentTypeRepository : BaseFilterableRepository<MediaContentType>, IMediaContentTypeRepository
{
    // Constructor accepting the database context.
    public MediaContentTypeRepository(DataContext dbContext, BaseFilterBuilder<MediaContentType> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
