using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramewok.Abstract.IRepositories;
using MediaHub.EntityFramewok.Abstract;
using MediaHub.Models;

namespace MediaHub.EntityFramewok.Repositories;
public class ActorMovieInfoRepository : BaseFilterableRepository<ActorMovieInfo>, IActorMovieInfoRepository
{
    // Constructor accepting the database context.
    public ActorMovieInfoRepository(DataContext dbContext) : base(dbContext) { }
}
