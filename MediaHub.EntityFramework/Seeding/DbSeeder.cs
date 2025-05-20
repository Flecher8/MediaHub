using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Seeding;
public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        SeedMediaContentTypes(context);
        SeedContentStatuses(context);
        SeedGenres(context);
        SeedCollectionUserRoles(context);
        // Add other seeding methods here for additional tables if needed
    }

    private static void SeedMediaContentTypes(DataContext context)
    {
        // Define the desired data
        var predefinedTypes = new List<MediaContentType>
        {
            new MediaContentType { Name = "Film" },
            new MediaContentType { Name = "Serial" },
            new MediaContentType { Name = "Game" },
            new MediaContentType { Name = "Anime" },
            new MediaContentType { Name = "Manga" }
        };

        // Get existing data from the database
        var existingTypes = context.MediaContentTypes.ToList();

        // Identify types that are missing and need to be added
        var missingTypes = predefinedTypes
            .Where(ps => !existingTypes.Any(es => es.Name == ps.Name))
            .ToList();

        // Identify extra types that are in the database but not in the predefined list
        var extraTypes = existingTypes
            .Where(es => !predefinedTypes.Any(ps => ps.Name == es.Name))
            .ToList();

        // Add missing types
        if (missingTypes.Any())
        {
            context.MediaContentTypes.AddRange(missingTypes);
        }

        // Remove extra types
        if (extraTypes.Any())
        {
            context.MediaContentTypes.RemoveRange(extraTypes);
        }

        // Save changes if there are any modifications
        if (missingTypes.Any() || extraTypes.Any())
        {
            context.SaveChanges();
        }
    }

    private static void SeedContentStatuses(DataContext context)
    {
        // Define the desired statuses
        var predefinedStatuses = new List<ContentStatus>
    {
        new ContentStatus { Name = "Planning" },
        new ContentStatus { Name = "In Progress" },
        new ContentStatus { Name = "Completed" },
        new ContentStatus { Name = "On Hold" },
        new ContentStatus { Name = "Dropped" },
        new ContentStatus { Name = "Not Interested" }
    };

        // Get existing data from the database
        var existingStatuses = context.ContentStatuses.ToList();

        // Identify statuses that are missing and need to be added
        var missingStatuses = predefinedStatuses
            .Where(ps => !existingStatuses.Any(es => es.Name == ps.Name))
            .ToList();

        // Identify extra statuses that are in the database but not in the predefined list
        var extraStatuses = existingStatuses
            .Where(es => !predefinedStatuses.Any(ps => ps.Name == es.Name))
            .ToList();

        // Add missing statuses
        if (missingStatuses.Any())
        {
            context.ContentStatuses.AddRange(missingStatuses);
        }

        // Remove extra statuses
        if (extraStatuses.Any())
        {
            context.ContentStatuses.RemoveRange(extraStatuses);
        }

        // Save changes if there are any modifications
        if (missingStatuses.Any() || extraStatuses.Any())
        {
            context.SaveChanges();
        }
    }

    private static void SeedGenres(DataContext context)
    {
        var predefinedGenres = new List<Genre>
        {
            new Genre { Name = "Action" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "Animation" },
            new Genre { Name = "Comedy" },
            new Genre { Name = "Crime" },
            new Genre { Name = "Documentary" },
            new Genre { Name = "Drama" },
            new Genre { Name = "Educational" },
            new Genre { Name = "Family" },
            new Genre { Name = "Fantasy" },
            new Genre { Name = "History" },
            new Genre { Name = "Horror" },
            new Genre { Name = "Kids" },
            new Genre { Name = "Music" },
            new Genre { Name = "Mystery" },
            new Genre { Name = "Romance" },
            new Genre { Name = "Sci-Fi" },
            new Genre { Name = "Sports" },
            new Genre { Name = "Strategy" },
            new Genre { Name = "Thriller" },
            new Genre { Name = "War" },
            new Genre { Name = "Western" }
        };

        var existing = context.Genres.ToList();

        var missing = predefinedGenres
            .Where(g => !existing.Any(e => e.Name == g.Name))
            .ToList();

        var extra = existing
            .Where(e => !predefinedGenres.Any(g => g.Name == e.Name))
            .ToList();

        if (missing.Any())
            context.Genres.AddRange(missing);

        if (extra.Any())
            context.Genres.RemoveRange(extra);

        if (missing.Any() || extra.Any())
            context.SaveChanges();
    }

    private static void SeedCollectionUserRoles(DataContext context)
    {
        var predefinedRoles = new List<CollectionUserRole>
        {
            new CollectionUserRole { Name = "Editor" },
            new CollectionUserRole { Name = "Viewer" }
        };

        var existing = context.CollectionUserRoles.ToList();

        // Add missing roles
        var missing = predefinedRoles
            .Where(pr => !existing.Any(er => er.Name == pr.Name))
            .ToList();
        if (missing.Any())
            context.CollectionUserRoles.AddRange(missing);

        // Remove any extra roles
        var extra = existing
            .Where(er => !predefinedRoles.Any(pr => pr.Name == er.Name))
            .ToList();
        if (extra.Any())
            context.CollectionUserRoles.RemoveRange(extra);

        if (missing.Any() || extra.Any())
            context.SaveChanges();
    }
}
