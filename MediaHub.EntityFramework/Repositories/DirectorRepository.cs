using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class DirectorRepository : BaseFilterableRepository<Director>, IDirectorRepository
{
    // Constructor accepting the database context.
    public DirectorRepository(DataContext dbContext, BaseFilterBuilder<Director> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
