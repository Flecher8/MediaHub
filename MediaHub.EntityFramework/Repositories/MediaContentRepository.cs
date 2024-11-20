﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class MediaContentRepository : BaseFilterableRepository<MediaContent>, IMediaContentRepository
{
    // Constructor accepting the database context.
    public MediaContentRepository(DataContext dbContext, BaseFilterBuilder<MediaContent> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
