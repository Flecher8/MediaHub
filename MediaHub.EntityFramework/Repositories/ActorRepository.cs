using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramewok;
using MediaHub.EntityFramewok.Abstract;
using MediaHub.EntityFramewok.Abstract.IRepositories;
using MediaHub.Models;

namespace MediaHub.EntityFramewok.Repositories;
public class ActorRepository : BaseFilterableRepository<Actor>, IActorRepository
{
    // Constructor accepting the database context.
    public ActorRepository(DataContext dbContext, BaseFilterBuilder<Actor> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
