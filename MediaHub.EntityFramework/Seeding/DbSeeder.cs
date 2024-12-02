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

        // Check for missing data
        var existingNames = context.MediaContentTypes.Select(mct => mct.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var missingTypes = predefinedTypes.Where(mct => !existingNames.Contains(mct.Name)).ToList();

        // Add missing data
        if (missingTypes.Any())
        {
            context.MediaContentTypes.AddRange(missingTypes);
            context.SaveChanges();
        }
    }
}
