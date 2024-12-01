using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class GamePublisherRepository : BaseFilterableRepository<GamePublisher>, IGamePublisherRepository
{
    // Constructor accepting the database context.
    public GamePublisherRepository(DataContext dbContext, BaseFilterBuilder<GamePublisher> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
