using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class AnimeRepository : BaseFilterableRepository<Anime>, IAnimeRepository
{
    // Constructor accepting the database context.
    public AnimeRepository(DataContext dbContext, BaseFilterBuilder<Anime> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
