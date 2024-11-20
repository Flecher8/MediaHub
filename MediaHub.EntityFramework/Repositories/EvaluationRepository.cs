using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models;


namespace MediaHub.EntityFramework.Repositories;
public class EvaluationRepository : BaseFilterableRepository<Evaluation>, IEvaluationRepository
{
    // Constructor accepting the database context.
    public EvaluationRepository(DataContext dbContext, BaseFilterBuilder<Evaluation> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
