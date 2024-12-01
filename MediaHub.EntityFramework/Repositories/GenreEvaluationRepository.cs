using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class GenreEvaluationRepository : BaseFilterableRepository<GenreEvaluation>, IGenreEvaluationRepository
{
    // Constructor accepting the database context.
    public GenreEvaluationRepository(DataContext dbContext, BaseFilterBuilder<GenreEvaluation> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
