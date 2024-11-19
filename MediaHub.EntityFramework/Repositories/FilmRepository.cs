﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramewok.Abstract.IRepositories;
using MediaHub.EntityFramewok.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.EntityFramewok;

namespace MediaHub.EntityFramework.Repositories;
public class FilmRepository : BaseFilterableRepository<Film>, IFilmRepository
{
    // Constructor accepting the database context.
    public FilmRepository(DataContext dbContext, BaseFilterBuilder<Film> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
