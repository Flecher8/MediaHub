using MediaHub.Models.Entities;

namespace MediaHub.EntityFramework.Seeding;
public static class DbSeeder
{
    public static void Seed(DataContext context)
    {
        SeedMediaContentTypes(context);
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
            .Where(pt => !existingTypes.Any(et => et.Name.Equals(pt.Name, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        // Identify extra types that are in the database but not in the predefined list
        var extraTypes = existingTypes
            .Where(et => !predefinedTypes.Any(pt => pt.Name.Equals(et.Name, StringComparison.OrdinalIgnoreCase)))
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
}
