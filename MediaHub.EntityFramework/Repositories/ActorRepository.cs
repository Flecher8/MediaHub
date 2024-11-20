using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class ActorRepository : BaseFilterableRepository<Actor>, IActorRepository
{
    // Constructor accepting the database context.
    public ActorRepository(DataContext dbContext, BaseFilterBuilder<Actor> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
