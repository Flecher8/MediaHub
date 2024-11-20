﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Repositories;
public class MovieInfoRepository : BaseFilterableRepository<MovieInfo>, IMovieInfoRepository
{
    // Constructor accepting the database context.
    public MovieInfoRepository(DataContext dbContext, BaseFilterBuilder<MovieInfo> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
