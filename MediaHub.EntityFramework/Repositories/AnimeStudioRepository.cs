using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class AnimeStudioRepository : BaseFilterableRepository<AnimeStudio>, IAnimeStudioRepository
{
    // Constructor accepting the database context.
    public AnimeStudioRepository(DataContext dbContext, BaseFilterBuilder<AnimeStudio> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
