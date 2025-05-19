using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.SerialDtos;

namespace MediaHub.Core.Services;
public class SerialService : ISerialService
{
    private readonly ISerialRepository _serialRepo;
    private readonly IMapper _mapper;

    public SerialService(ISerialRepository serialRepo, IMapper mapper)
    {
        _serialRepo = serialRepo;
        _mapper = mapper;
    }

    public async Task<SerialDto?> GetByMediaContentIdAsync(Guid mediaContentId)
    {
        var filtered = await _serialRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(s => s.MediaContentId == mediaContentId)
            .Include(s => s.MediaContent)
            .Include(s => s.MovieInfo!)
            .Include(s => s.MovieInfo!.Actors)
            .Include(s => s.MovieInfo!.Directors)
        );

        var entity = filtered.FirstOrDefault();
        return entity == null
            ? null
            : _mapper.Map<SerialDto>(entity);
    }
}
