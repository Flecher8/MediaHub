using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class GameRepository : BaseFilterableRepository<Game>, IGameRepository
{
    // Constructor accepting the database context.
    public GameRepository(DataContext dbContext, BaseFilterBuilder<Game> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
