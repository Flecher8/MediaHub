﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class MediaContentTypeRepository : BaseFilterableRepository<MediaContentType>, IMediaContentTypeRepository
{
    // Constructor accepting the database context.
    public MediaContentTypeRepository(DataContext dbContext, BaseFilterBuilder<MediaContentType> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
