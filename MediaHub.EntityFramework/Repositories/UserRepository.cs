using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class UserRepository : BaseFilterableRepository<User>, IUserRepository
{
    // Constructor accepting the database context.
    public UserRepository(DataContext dbContext, BaseFilterBuilder<User> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
