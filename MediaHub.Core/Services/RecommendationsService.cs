using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Services;
public class RecommendationsService : IRecommendationsService
{
    private readonly IGenreEvaluationRepository _genreEvalRepo;
    private readonly IMediaContentRepository _mediaRepo;
    private readonly IMediaInteractionStatusRepository _misRepo;
    private readonly IMapper _mapper;

    public RecommendationsService(
        IGenreEvaluationRepository genreEvalRepo,
        IMediaContentRepository mediaRepo,
        IMediaInteractionStatusRepository misRepo,
        IMapper mapper)
    {
        _genreEvalRepo = genreEvalRepo;
        _mediaRepo = mediaRepo;
        _misRepo = misRepo;
        _mapper = mapper;
    }

    public async Task<List<MediaContentDto>> GetRecommendationsAsync(
            Guid collectionId,
            int page = 1,
            int pageSize = 100)
    {
        // 1) Load per-genre “like” scores for this collection
        var genrePoints = await LoadGenrePointsAsync(collectionId);

        // 2) Find all media already in this collection, to exclude
        var existingStatuses = await _misRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mis => mis.RecommendationCollectionId == collectionId));
        var inCollectionIds = existingStatuses
            .Select(mis => mis.MediaContentId)
            .ToHashSet();

        // 3) Load all candidate MediaContent not yet in the collection
        var candidates = await _mediaRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mc => !inCollectionIds.Contains(mc.MediaContentId))
              .Include(mc => mc.Genres)
              .Include(mc => mc.MediaContentType)
        );

        // 4) Score each candidate in parallel, report progress
        int total = candidates.Count;
        int done = 0;
        var bag = new ConcurrentBag<(MediaContent Content, double Score)>();

        Parallel.ForEach(candidates,
            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            mc =>
            {
                double genreScore = CalculateNormalizedGenreScore(mc.Genres, genrePoints);
                double ratingScore = mc.Rating / 10.0;
                double recencyScore = CalculateRecencyScore(mc.ReleaseDate);

                // blend with weights: 50% rating, 40% genre, 10% recency
                double totalScore = ratingScore * 0.5
                                  + genreScore * 0.4
                                  + recencyScore * 0.1;

                bag.Add((mc, totalScore));

                Interlocked.Increment(ref done);
            }
        );

        // 5) Order, then page
        var paged = bag
            .OrderByDescending(x => x.Score)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => x.Content)
            .ToList();

        // 6) Map to DTOs
        return paged
            .Select(mc => _mapper.Map<MediaContentDto>(mc))
            .ToList();
    }

    public async Task<List<MediaContentDto>> GetRecommendationsForGuestAsync(
            int page = 1,
            int pageSize = 100)
    {
        // 1) Load all media (no need to include pictures)
        var candidates = await _mediaRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(_ => true)
              .Include(mc => mc.Genres)
              .Include(mc => mc.MediaContentType)
        );

        int total = candidates.Count;
        int done = 0;
        var bag = new ConcurrentBag<(MediaContent Content, double Score)>();

        // 2) Score in parallel, report progress
        Parallel.ForEach(candidates,
            new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            mc =>
            {
                double ratingScore = mc.Rating / 10.0;
                double recencyScore = CalculateRecencyScore(mc.ReleaseDate);

                // guests: 90% rating, 10% recency
                double totalScore = ratingScore * 0.9
                                  + recencyScore * 0.1;

                bag.Add((mc, totalScore));

                Interlocked.Increment(ref done);
            }
        );

        // 3) Order, then page
        var paged = bag
            .OrderByDescending(x => x.Score)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => x.Content)
            .ToList();

        // 4) Map to DTOs
        return paged
            .Select(mc => _mapper.Map<MediaContentDto>(mc))
            .ToList();
    }

    public async Task<int> GetRecommendationsPageCountAsync(
            Guid collectionId,
            int pageSize = 100)
    {
        // 1) determine how many candidates:
        var existingStatuses = await _misRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mis => mis.RecommendationCollectionId == collectionId));
        var inCollectionIds = existingStatuses
            .Select(mis => mis.MediaContentId)
            .ToHashSet();

        var allCandidates = await _mediaRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(mc => !inCollectionIds.Contains(mc.MediaContentId)));

        int totalCount = allCandidates.Count;
        return (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    public async Task<int> GetRecommendationsForGuestPageCountAsync(
        int pageSize = 100)
    {
        // simply total media count
        var all = await _mediaRepo.GetAllAsync();
        int totalCount = all.Count;
        return (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    // ——— Helpers ———

    // Load the “points” assigned to each genre in this collection
    private async Task<Dictionary<Guid, double>> LoadGenrePointsAsync(Guid collectionId)
    {
        var list = await _genreEvalRepo.GetFilteredItemsAsync(fb =>
            fb.WithFilter(ge => ge.RecommendationCollectionId == collectionId));
        return list.ToDictionary(ge => ge.GenreId, ge => ge.Points);
    }

    // Compute the **normalized** genre score for one item:
    //   sum of points for its genres, divided by number of genres
    //   so that having 1 high-score genre isn’t overshadowed by having 5 low-score ones.
    private double CalculateNormalizedGenreScore(
        IReadOnlyCollection<Genre> itemGenres,
        Dictionary<Guid, double> pointsByGenre)
    {
        if (!itemGenres.Any()) return 0.0;
        double sum = itemGenres
            .Select(g => pointsByGenre.TryGetValue(g.GenreId, out var p) ? p : 0.0)
            .Sum();
        return sum / itemGenres.Count;
    }

    // Compute a recency score in [0,1]:
    //   1.0 for items released today
    //   0.0 for items older than, say, 5 years
    private double CalculateRecencyScore(DateTime releaseDate)
    {
        double daysOld = (DateTime.UtcNow - releaseDate).TotalDays;
        const double maxDays = 5 * 365; // 5 years
        double score = 1.0 - (daysOld / maxDays);
        return Math.Clamp(score, 0.0, 1.0);
    }
}
