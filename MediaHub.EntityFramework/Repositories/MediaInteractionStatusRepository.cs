using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class MediaInteractionStatusRepository : BaseFilterableRepository<MediaInteractionStatus>, IMediaInteractionStatusRepository
{
    // Constructor accepting the database context.
    public MediaInteractionStatusRepository(DataContext dbContext, BaseFilterBuilder<MediaInteractionStatus> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
