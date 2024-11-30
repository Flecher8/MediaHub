using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class SerialRepository : BaseFilterableRepository<Serial>, ISerialRepository
{
    // Constructor accepting the database context.
    public SerialRepository(DataContext dbContext, BaseFilterBuilder<Serial> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
