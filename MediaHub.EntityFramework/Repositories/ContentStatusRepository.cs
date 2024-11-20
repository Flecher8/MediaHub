using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class ContentStatusRepository : BaseFilterableRepository<ContentStatus>, IContentStatusRepository
{
    // Constructor accepting the database context.
    public ContentStatusRepository(DataContext dbContext, BaseFilterBuilder<ContentStatus> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
