using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Seeding;
public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        SeedMediaContentTypes(context);
        SeedContentStatuses(context);
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
}
