using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class RoleRepository : BaseFilterableRepository<UserRole>, IRoleRepository
{
    // Constructor accepting the database context.
    public RoleRepository(DataContext dbContext, BaseFilterBuilder<UserRole> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
