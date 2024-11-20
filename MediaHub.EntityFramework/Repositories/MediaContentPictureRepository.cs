using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.EntityFramework.Abstract;
using MediaHub.Models;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.EntityFramework.Repositories;
public class MediaContentPictureRepository : BaseFilterableRepository<MediaContentPicture>, IMediaContentPictureRepository
{
    // Constructor accepting the database context.
    public MediaContentPictureRepository(DataContext dbContext, BaseFilterBuilder<MediaContentPicture> filterBuilder)
        : base(dbContext, filterBuilder)
    {
    }
}
