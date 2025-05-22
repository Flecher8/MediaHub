using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.EvaluationDtos;

namespace MediaHub.Core.Services;
public class EvaluationService : IEvaluationService
{
    private readonly IEvaluationRepository _repo;
    private readonly IMapper _mapper;

    public EvaluationService(IEvaluationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<EvaluationDto>> GetAllAsync()
    {
        var entities = await _repo.GetAllAsync();
        return _mapper.Map<List<EvaluationDto>>(entities);
    }
}
