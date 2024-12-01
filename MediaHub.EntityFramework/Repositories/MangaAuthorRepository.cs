using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class MangaAuthorRepository : BaseFilterableRepository<MangaAuthor>, IMangaAuthorRepository
{
    // Constructor accepting the database context.
    public MangaAuthorRepository(DataContext dbContext, BaseFilterBuilder<MangaAuthor> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
