﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramewok.Abstract.IRepositories;
using MediaHub.EntityFramewok.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramewok;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class GameTagRepository : BaseFilterableRepository<GameTag>, IGameTagRepository
{
    // Constructor accepting the database context.
    public GameTagRepository(DataContext dbContext, BaseFilterBuilder<GameTag> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
