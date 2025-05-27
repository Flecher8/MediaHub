using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MediaInteractionStatusDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class MediaInteractionStatusService : IMediaInteractionStatusService
{
    private readonly IMediaInteractionStatusRepository _misRepo;
    private readonly IContentStatusRepository _csRepo;
    private readonly IEvaluationRepository _evalRepo;
    private readonly IMediaContentRepository _mediaRepo;
    private readonly IRecommendationCollectionRepository _recRepo;
    private readonly IGenreEvaluationRepository _genreEvalRepo;
    private readonly IMapper _mapper;

    public MediaInteractionStatusService(
        IMediaInteractionStatusRepository misRepo,
        IContentStatusRepository csRepo,
        IEvaluationRepository evalRepo,
        IMediaContentRepository mediaRepo,
        IRecommendationCollectionRepository recRepo,
        IGenreEvaluationRepository genreEvalRepo,
        IMapper mapper)
    {
        _misRepo = misRepo;
        _csRepo = csRepo;
        _evalRepo = evalRepo;
        _mediaRepo = mediaRepo;
        _recRepo = recRepo;
        _genreEvalRepo = genreEvalRepo;
        _mapper = mapper;
    }

    public async Task<MediaInteractionStatusDto> AddAsync(CreateMediaInteractionStatusDto dto)
    {
        // validate media & collection exist
        if (await _mediaRepo.GetByIdAsync(dto.MediaContentId) is null)
            throw new ArgumentException("MediaContent not found.");
        if (await _recRepo.GetByIdAsync(dto.RecommendationCollectionId) is null)
            throw new ArgumentException("RecommendationCollection not found.");

        // **prevent duplicates**: no two statuses with same media+collection
        var dup = await _misRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mis =>
                mis.MediaContentId == dto.MediaContentId &&
                mis.RecommendationCollectionId == dto.RecommendationCollectionId));
        if (dup.Any())
            throw new ArgumentException("This media is already in that collection.");

        // load defaults
        var status = (await _csRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(s => s.Name == "In Progress"))).FirstOrDefault()
            ?? throw new InvalidOperationException("'In Progress' ContentStatus is missing.");
        var eval = (await _evalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(e => e.Name == "None"))).FirstOrDefault()
            ?? throw new InvalidOperationException("'None' Evaluation is missing.");

        // create & save
        var entity = new MediaInteractionStatus
        {
            MediaContentId = dto.MediaContentId,
            RecommendationCollectionId = dto.RecommendationCollectionId,
            ContentStatusId = status.ContentStatusId,
            EvaluationId = eval.EvaluationId
        };
        await _misRepo.AddAsync(entity);

        // map back
        return _mapper.Map<MediaInteractionStatusDto>(entity);
    }

    public async Task<MediaInteractionStatusDto> UpdateAsync(UpdateMediaInteractionStatusDto dto)
    {
        var mis = await _misRepo.GetByIdAsync(dto.MediaInteractionStatusId)
                  ?? throw new KeyNotFoundException("MediaInteractionStatus not found.");

        var oldEvalId = mis.EvaluationId;

        // validate the new ContentStatus exists:
        var csList = await _csRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(c => c.ContentStatusId == dto.ContentStatusId));
        if (!csList.Any())
            throw new ArgumentException("ContentStatus not found.");
        mis.ContentStatusId = dto.ContentStatusId;

        // validate the new Evaluation exists:
        var evList = await _evalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(e => e.EvaluationId == dto.EvaluationId));
        if (!evList.Any())
            throw new ArgumentException("Evaluation not found.");
        mis.EvaluationId = dto.EvaluationId;

        // persist
        await _misRepo.UpdateAsync(mis);

        // adjust genre‐points for this single MIS
        await AdjustGenrePoints(
            mis.RecommendationCollectionId,
            mis.MediaContentId,
            newEvalId: mis.EvaluationId,
            oldEvalId: oldEvalId);


        return _mapper.Map<MediaInteractionStatusDto>(mis);
    }

    public async Task DeleteAsync(Guid id)
    {
        var mis = await _misRepo.GetByIdAsync(id)
              ?? throw new KeyNotFoundException();

        // remove points contributed by this MIS
        await AdjustGenrePoints(
            mis.RecommendationCollectionId,
            mis.MediaContentId,
            newEvalId: null,
            oldEvalId: mis.EvaluationId);

        await _misRepo.DeleteAsync(id);
    }

    public async Task<MediaInteractionStatusDto?> GetByIdAsync(Guid id)
    {
        // include the navs so AutoMapper has all the data
        var list = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis => mis.MediaInteractionStatusId == id)
            .Include(mis => mis.MediaContent)
            .Include(mis => mis.ContentStatus)
            .Include(mis => mis.Evaluation)
            .Include(mis => mis.RecommendationCollection)
        );

        var e = list.FirstOrDefault();
        return e == null ? null : _mapper.Map<MediaInteractionStatusDto>(e);
    }

    public async Task<List<MediaContentDto>> GetMediaByCollectionAsync(Guid recommendationCollectionId)
    {
        // load all statuses for that collection, including the MediaContent navigation and its children
        var list = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis => mis.RecommendationCollectionId == recommendationCollectionId)
            .Include(mis => mis.MediaContent)
            .Include(mis => mis.MediaContent.Genres)
            .Include(mis => mis.MediaContent.MediaContentPictures)
            .Include(mis => mis.MediaContent.MediaContentType)
        );

        // project to MediaContentDto
        return list
            .Select(mis => _mapper.Map<MediaContentDto>(mis.MediaContent))
            .ToList();
    }

    public async Task DeleteByCollectionAndMediaAsync(Guid recommendationCollectionId, Guid mediaContentId)
    {
        // find the matching status entry (there should be at most one)
        var matches = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis =>
                mis.RecommendationCollectionId == recommendationCollectionId &&
                mis.MediaContentId == mediaContentId));

        var mis = matches.FirstOrDefault();
        if (mis == null)
            throw new KeyNotFoundException("No MediaInteractionStatus found for that collection + media pair.");

        // remove points
        await AdjustGenrePoints(
            mis.RecommendationCollectionId,
            mis.MediaContentId,
            newEvalId: null,
            oldEvalId: mis.EvaluationId);

        await _misRepo.DeleteAsync(mis.MediaInteractionStatusId);
    }

    public async Task<MediaInteractionStatusDto?> GetByCollectionAndMediaAsync(Guid recommendationCollectionId, Guid mediaContentId)
    {
        // load the single MIS entry (if any), with all navigations
        var list = await _misRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(mis =>
                mis.RecommendationCollectionId == recommendationCollectionId &&
                mis.MediaContentId == mediaContentId)
            .Include(mis => mis.MediaContent)
            .Include(mis => mis.ContentStatus)
            .Include(mis => mis.Evaluation)
            .Include(mis => mis.RecommendationCollection)
        );

        var mis = list.FirstOrDefault();
        return mis == null
            ? null
            : _mapper.Map<MediaInteractionStatusDto>(mis);
    }

    // ratingName is “None”, “1”…“10”
    private int ToDelta(string ratingName)
    {
        if (!int.TryParse(ratingName, out var r) || r == 5) return 0;
        return r - 5; // e.g. 1→-4, 4→-1, 6→+1, 10→+5
    }

    private async Task AdjustGenrePoints(
    Guid collectionId,
    Guid mediaContentId,
    Guid? newEvalId,
    Guid? oldEvalId)
    {
        // 1) load the media with its Genres navigation
        var mediaList = await _mediaRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(m => m.MediaContentId == mediaContentId)
            .Include(m => m.Genres)
        );
        var media = mediaList.FirstOrDefault()
            ?? throw new KeyNotFoundException($"MediaContent {mediaContentId} not found.");

        // 2) lookup the "None" evaluation so we can compare
        var noneEval = (await _evalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(e => e.Name == "None")))
            .FirstOrDefault()
            ?? throw new InvalidOperationException("'None' Evaluation is missing.");

        // 3) compute the old and new deltas
        int ToDelta(string name)
            => int.TryParse(name, out var r) ? r - 5 : 0;

        int oldDelta = 0, newDelta = 0;
        if (oldEvalId.HasValue && oldEvalId != noneEval.EvaluationId)
        {
            var old = await _evalRepo.GetByIdAsync(oldEvalId.Value)
                      ?? throw new KeyNotFoundException("Old Evaluation not found.");
            oldDelta = ToDelta(old.Name);
        }
        if (newEvalId.HasValue && newEvalId != noneEval.EvaluationId)
        {
            var nw = await _evalRepo.GetByIdAsync(newEvalId.Value)
                     ?? throw new KeyNotFoundException("New Evaluation not found.");
            newDelta = ToDelta(nw.Name);
        }

        var delta = newDelta - oldDelta;
        if (delta == 0) return;

        // 4) load the GenreEvaluation rows for this collection & those genres
        var genreIds = media.Genres.Select(g => g.GenreId).ToList();
        var ges = await _genreEvalRepo.GetFilteredItemsAsync(fb => fb
            .WithFilter(ge =>
                ge.RecommendationCollectionId == collectionId
             && genreIds.Contains(ge.GenreId))
        );

        // 5) apply the adjustment
        foreach (var ge in ges)
        {
            ge.Points += delta;
            await _genreEvalRepo.UpdateAsync(ge);
        }
    }
}
