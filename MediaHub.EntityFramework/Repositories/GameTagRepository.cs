using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class GameTagRepository : BaseFilterableRepository<GameTag>, IGameTagRepository
{
    // Constructor accepting the database context.
    public GameTagRepository(DataContext dbContext, BaseFilterBuilder<GameTag> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
