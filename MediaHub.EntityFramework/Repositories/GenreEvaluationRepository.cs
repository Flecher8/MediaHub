using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class GenreEvaluationRepository : BaseFilterableRepository<GenreEvaluation>, IGenreEvaluationRepository
{
    // Constructor accepting the database context.
    public GenreEvaluationRepository(DataContext dbContext, BaseFilterBuilder<GenreEvaluation> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
