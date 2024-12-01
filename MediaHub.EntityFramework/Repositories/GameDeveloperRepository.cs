using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class GameDeveloperRepository : BaseFilterableRepository<GameDeveloper>, IGameDeveloperRepository
{
    // Constructor accepting the database context.
    public GameDeveloperRepository(DataContext dbContext, BaseFilterBuilder<GameDeveloper> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
