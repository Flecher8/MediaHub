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
public class GameDeveloperRepository : BaseFilterableRepository<GameDeveloper>, IGameDeveloperRepository
{
    // Constructor accepting the database context.
    public GameDeveloperRepository(DataContext dbContext, BaseFilterBuilder<GameDeveloper> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
