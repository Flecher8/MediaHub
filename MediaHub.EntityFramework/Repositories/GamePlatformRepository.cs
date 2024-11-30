using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class GamePlatformRepository : BaseFilterableRepository<GamePlatform>, IGamePlatformRepository
{
    // Constructor accepting the database context.
    public GamePlatformRepository(DataContext dbContext, BaseFilterBuilder<GamePlatform> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
