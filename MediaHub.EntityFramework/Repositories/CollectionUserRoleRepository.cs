using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class CollectionUserRoleRepository : BaseFilterableRepository<CollectionUserRole>, ICollectionUserRoleRepository
{
    // Constructor accepting the database context.
    public CollectionUserRoleRepository(DataContext dbContext, BaseFilterBuilder<CollectionUserRole> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
