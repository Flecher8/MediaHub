﻿using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;

public class GenreRepository : BaseFilterableRepository<Genre>, IGenreRepository
{
    // Constructor accepting the database context.
    public GenreRepository(DataContext dbContext, BaseFilterBuilder<Genre> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
