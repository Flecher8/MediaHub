using MediaHub.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.EntityFramework
{
    public class DataContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override DbSet<User> Users { get; set; }
        public override DbSet<UserRole> Roles { get; set; }
        public DbSet<CollectionUserRole> CollectionUserRoles { get; set; }
        public DbSet<ContentStatus> ContentStatuses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreEvaluation> GenreEvaluations { get; set; }
        public DbSet<MediaContent> MediaContents { get; set; }
        public DbSet<MediaContentPicture> MediaContentPictures { get; set; }
        public DbSet<MediaContentType> MediaContentTypes { get; set; }
        public DbSet<MediaInteractionStatus> MediaInteractionStatuses { get; set; }
        public DbSet<RecommendationCollection> RecommendationCollections { get; set; }
        public DbSet<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<MovieInfo> MovieInfos { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<GamePublisher> GamePublishers { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeStudio> AnimeStudios { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<MangaAuthor> MangaAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CollectionUserRole entity
            modelBuilder.Entity<CollectionUserRole>(entity =>
            {
                entity.HasKey(cr => cr.CollectionUserRoleId);

                entity.Property(cr => cr.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(cr => cr.Name)
                      .IsUnique();

                // Configure one-to-many relationship with RecommendationCollectionUserAccess
                entity.HasMany(cr => cr.RecommendationCollectionUserAccesses)
                      .WithOne(rcua => rcua.CollectionUserRole)
                      .HasForeignKey(rcua => rcua.CollectionUserRoleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ContentStatus entity
            modelBuilder.Entity<ContentStatus>(entity =>
            {
                entity.HasKey(cs => cs.ContentStatusId);

                entity.Property(cs => cs.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(cs => cs.Name)
                      .IsUnique();

                // Configure one-to-many relationship with MediaInteractionStatus
                entity.HasMany(cs => cs.MediaInteractionStatuses)
                      .WithOne(mis => mis.ContentStatus)
                      .HasForeignKey(mis => mis.ContentStatusId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Evaluation entity
            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(ev => ev.EvaluationId);

                entity.Property(ev => ev.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(ev => ev.Name)
                      .IsUnique();

                // Configure one-to-many relationship with MediaInteractionStatus
                entity.HasMany(ev => ev.MediaInteractionStatuses)
                      .WithOne(mis => mis.Evaluation)
                      .HasForeignKey(mis => mis.EvaluationId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.SetNull);
            });


            // Configure Genre entity
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.GenreId);

                entity.Property(g => g.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(g => g.Name)
                      .IsUnique();

                entity.HasMany(g => g.GenreEvaluations)
                      .WithOne(ge => ge.Genre)
                      .HasForeignKey(ge => ge.GenreId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure GenreEvaluation entity
            modelBuilder.Entity<GenreEvaluation>(entity =>
            {
                entity.HasKey(ge => ge.GenreEvaluationId);

                entity.HasOne(ge => ge.RecommendationCollection)
                      .WithMany(rc => rc.GenreEvaluations)
                      .HasForeignKey(ge => ge.RecommendationCollectionId)
                      .IsRequired();

                entity.HasOne(ge => ge.Genre)
                      .WithMany(g => g.GenreEvaluations)
                      .HasForeignKey(ge => ge.GenreId)
                      .IsRequired();

                entity.Property(ge => ge.Points).HasDefaultValue(0);
            });

            // Configure MediaContent entity
            modelBuilder.Entity<MediaContent>(entity =>
            {
                entity.HasKey(mc => mc.MediaContentId);

                entity.Property(mc => mc.Title).IsRequired().HasMaxLength(200);

                entity.Property(mc => mc.Description).HasMaxLength(10000);

                entity.Property(mc => mc.Rating).HasDefaultValue(0);

                entity.Property(mc => mc.ReleaseDate).IsRequired();

                entity.Property(mc => mc.MainPictureLink).HasMaxLength(500);

                entity.HasIndex(mc => mc.Title).IsUnique();

                entity.HasMany(mc => mc.MediaInteractionStatuses)
                      .WithOne(mis => mis.MediaContent)
                      .HasForeignKey(mis => mis.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(mc => mc.MediaContentPictures)
                      .WithOne(mcp => mcp.MediaContent)
                      .HasForeignKey(mcp => mcp.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.MediaContentType)
                      .WithMany(mct => mct.MediaContents)
                      .HasForeignKey(mc => mc.MediaContentTypeId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade); // TODO Can cause errors...

                entity.HasOne(mc => mc.Film)
                      .WithOne(f => f.MediaContent)
                      .HasForeignKey<Film>(f => f.MediaContentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Serial)
                      .WithOne(s => s.MediaContent)
                      .HasForeignKey<Serial>(s => s.MediaContentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Game)
                      .WithOne(g => g.MediaContent)
                      .HasForeignKey<Game>(g => g.MediaContentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(mc => mc.Anime)
                      .WithOne(a => a.MediaContent)
                      .HasForeignKey<Anime>(a => a.MediaContentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Manga)
                      .WithOne(m => m.MediaContent)
                      .HasForeignKey<Manga>(m => m.MediaContentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(mc => mc.Genres)
                          .WithMany(g => g.MediaContents)
                          .UsingEntity<Dictionary<string, object>>(
                              "MediaContentGenre",
                              join => join.HasOne<Genre>()
                                          .WithMany()
                                          .HasForeignKey("GenreId")
                                          .OnDelete(DeleteBehavior.Cascade),
                              join => join.HasOne<MediaContent>()
                                          .WithMany()
                                          .HasForeignKey("MediaContentId")
                                          .OnDelete(DeleteBehavior.Cascade)
                          );
            });

            // Configure MediaContentPicture entity
            modelBuilder.Entity<MediaContentPicture>(entity =>
            {
                entity.HasKey(mcp => mcp.PictureId);

                entity.Property(mcp => mcp.PictureLink).IsRequired().HasMaxLength(500);

                entity.HasOne(mcp => mcp.MediaContent)
                      .WithMany(mc => mc.MediaContentPictures)
                      .HasForeignKey(mcp => mcp.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure MediaContentType entity
            modelBuilder.Entity<MediaContentType>(entity =>
            {
                // Primary Key
                entity.HasKey(mct => mct.TypeId);

                // Property Configuration
                entity.Property(mct => mct.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                // Unique Index on Name
                entity.HasIndex(mct => mct.Name)
                      .IsUnique();

                // One-to-Many Relationship with MediaContent
                entity.HasMany(mct => mct.MediaContents)
                      .WithOne(mc => mc.MediaContentType)
                      .HasForeignKey(mc => mc.MediaContentTypeId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Configure MediaInteractionStatus entity
            modelBuilder.Entity<MediaInteractionStatus>(entity =>
            {
                // Primary Key
                entity.HasKey(mis => mis.MediaInteractionStatusId);

                entity.HasOne(mis => mis.MediaContent)
                      .WithMany(mc => mc.MediaInteractionStatuses)
                      .HasForeignKey(mis => mis.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mis => mis.ContentStatus)
                      .WithMany(cs => cs.MediaInteractionStatuses)
                      .HasForeignKey(mis => mis.ContentStatusId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(mis => mis.RecommendationCollection)
                      .WithMany(rc => rc.MediaInteractionStatus)
                      .HasForeignKey(mis => mis.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mis => mis.Evaluation)
                      .WithMany(ev => ev.MediaInteractionStatuses)
                      .HasForeignKey(mis => mis.EvaluationId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.SetNull);
            });


            // Configure RecommendationCollection entity
            modelBuilder.Entity<RecommendationCollection>(entity =>
            {
                entity.HasKey(rc => rc.CollectionId);

                entity.Property(rc => rc.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasOne(rc => rc.CreatorUser)
                      .WithMany(u => u.RecommendationCollections)
                      .HasForeignKey(rc => rc.CreatorUserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(rc => rc.MediaInteractionStatus)
                      .WithOne(mis => mis.RecommendationCollection)
                      .HasForeignKey(mis => mis.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(rc => rc.GenreEvaluations)
                      .WithOne(ge => ge.RecommendationCollection)
                      .HasForeignKey(ge => ge.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(rc => rc.RecommendationCollectionUserAccesses)
                      .WithOne(rcua => rcua.RecommendationCollection)
                      .HasForeignKey(rcua => rcua.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure RecommendationCollectionUserAccess entity
            modelBuilder.Entity<RecommendationCollectionUserAccess>(entity =>
            {
                entity.HasKey(rcua => rcua.UserAccessId);

                entity.HasOne(rcua => rcua.User)
                      .WithMany(u => u.RecommendationCollectionUserAccess)
                      .HasForeignKey(rcua => rcua.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rcua => rcua.RecommendationCollection)
                      .WithMany(rc => rc.RecommendationCollectionUserAccesses)
                      .HasForeignKey(rcua => rcua.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(rcua => rcua.CollectionUserRole)
                      .WithMany(cr => cr.RecommendationCollectionUserAccesses)
                      .HasForeignKey(rcua => rcua.CollectionUserRoleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Configure Film entity
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(f => f.FilmId);

                entity.HasOne(f => f.MediaContent)
                      .WithOne(mc => mc.Film)
                      .HasForeignKey<Film>(f => f.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.MovieInfo)
                      .WithOne(mi => mi.Film)
                      .HasForeignKey<Film>(f => f.MovieInfoId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Serial entity
            modelBuilder.Entity<Serial>(entity =>
            {
                // Primary Key
                entity.HasKey(s => s.SerialId);

                entity.HasOne(s => s.MediaContent)
                      .WithOne(mc => mc.Serial)
                      .HasForeignKey<Serial>(s => s.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.MovieInfo)
                      .WithOne(mi => mi.Serial)
                      .HasForeignKey<Serial>(s => s.MovieInfoId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(s => s.NumberOfSeasons)
                      .HasDefaultValue(0)
                      .IsRequired();

                entity.Property(s => s.NumberOfEpisodes)
                      .HasDefaultValue(0)
                      .IsRequired();
            });


            // Configure MovieInfo entity
            modelBuilder.Entity<MovieInfo>(entity =>
            {
                entity.HasKey(mi => mi.MovieInfoId);
                entity.Property(mi => mi.DurationInMinutes).HasDefaultValue(0);

                entity.HasOne(mi => mi.Film)
                      .WithOne(f => f.MovieInfo)
                      .HasForeignKey<Film>(f => f.MovieInfoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mi => mi.Serial)
                      .WithOne(s => s.MovieInfo)
                      .HasForeignKey<Serial>(s => s.MovieInfoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(mi => mi.Directors)
                     .WithMany(d => d.MovieInfos)
                     .UsingEntity<Dictionary<string, object>>(
                         "DirectorMovieInfo", // Name of the join table
                         join => join.HasOne<Director>()
                                     .WithMany()
                                     .HasForeignKey("DirectorId")
                                     .OnDelete(DeleteBehavior.Cascade),
                         join => join.HasOne<MovieInfo>()
                                     .WithMany()
                                     .HasForeignKey("MovieInfoId")
                                     .OnDelete(DeleteBehavior.Cascade)
                     );

                entity.HasMany(mi => mi.Actors)
                      .WithMany(a => a.MovieInfos)
                      .UsingEntity<Dictionary<string, object>>(
                          "ActorMovieInfo", // Name of the join table
                          join => join.HasOne<Actor>()
                                      .WithMany()
                                      .HasForeignKey("ActorId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<MovieInfo>()
                                      .WithMany()
                                      .HasForeignKey("MovieInfoId")
                                      .OnDelete(DeleteBehavior.Cascade)
                      );
            });

            // Configure Director entity
            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(d => d.DirectorId);

                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });


            // Configure Actor entity
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(a => a.ActorId);

                entity.Property(a => a.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // Configure Game entity
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.Property(g => g.MetacriticRating).HasDefaultValue(0);

                entity.Property(g => g.PlaytimeHours).HasDefaultValue(0);

                entity.Property(g => g.EsrbRating).HasDefaultValue(0);

                entity.HasOne(g => g.MediaContent)
                      .WithOne(mc => mc.Game)
                      .HasForeignKey<Game>(g => g.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(g => g.GamePlatforms)
                      .WithMany(gp => gp.Games)
                      .UsingEntity<Dictionary<string, object>>(
                          "GamePlatformGame", // Name of the join table
                          join => join.HasOne<GamePlatform>()
                                      .WithMany()
                                      .HasForeignKey("GamePlatformId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<Game>()
                                      .WithMany()
                                      .HasForeignKey("GameId")
                                      .OnDelete(DeleteBehavior.Cascade)
                       );

                entity.HasMany(g => g.GameDevelopers)
                      .WithMany(gd => gd.Games)
                      .UsingEntity<Dictionary<string, object>>(
                          "GameDeveloperGame", // Join table name
                          join => join.HasOne<GameDeveloper>()
                                      .WithMany()
                                      .HasForeignKey("GameDeveloperId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<Game>()
                                      .WithMany()
                                      .HasForeignKey("GameId")
                                      .OnDelete(DeleteBehavior.Cascade)
                        );

                entity.HasMany(g => g.GamePublishers)
                      .WithMany(gp => gp.Games)
                      .UsingEntity<Dictionary<string, object>>(
                          "GamePublisherGame",
                          join => join.HasOne<GamePublisher>()
                                      .WithMany()
                                      .HasForeignKey("GamePublisherId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<Game>()
                                      .WithMany()
                                      .HasForeignKey("GameId")
                                      .OnDelete(DeleteBehavior.Cascade)
                    );

                entity.HasMany(g => g.GameTags)
                      .WithMany(gt => gt.Games)
                      .UsingEntity<Dictionary<string, object>>(
                          "GameTagGame",
                          join => join.HasOne<GameTag>()
                                      .WithMany()
                                      .HasForeignKey("GameTagId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<Game>()
                                      .WithMany()
                                      .HasForeignKey("GameId")
                                      .OnDelete(DeleteBehavior.Cascade)
                    );
            });

            // Configure GamePlatform entity
            modelBuilder.Entity<GamePlatform>(entity =>
            {
                entity.HasKey(gp => gp.GamePlatformId);

                entity.Property(gp => gp.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gp => gp.Name).IsUnique();
            });

            // Configure GameDeveloper entity
            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.HasKey(gd => gd.GameDeveloperId);

                entity.Property(gd => gd.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gd => gd.Name).IsUnique();
            });

            // Configure GamePublisher entity
            modelBuilder.Entity<GamePublisher>(entity =>
            {
                entity.HasKey(gp => gp.GamePublisherId);

                entity.Property(gp => gp.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gp => gp.Name).IsUnique();
            });


            // Configure GameTag entity
            modelBuilder.Entity<GameTag>(entity =>
            {
                entity.HasKey(gt => gt.GameTagId);

                entity.Property(gt => gt.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gt => gt.Name).IsUnique();
            });

            // Configure Anime entity
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.HasKey(a => a.AnimeId);

                entity.Property(a => a.Rank)
                      .HasDefaultValue(0);

                entity.Property(a => a.NumberOfEpisodes)
                      .HasDefaultValue(0);

                entity.Property(a => a.StartDate)
                      .IsRequired();

                entity.Property(a => a.EndDate)
                      .IsRequired();

                entity.HasOne(a => a.MediaContent)
                      .WithOne(mc => mc.Anime)
                      .HasForeignKey<Anime>(a => a.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.AnimeStudios)
                      .WithMany(studio => studio.Animes)
                      .UsingEntity<Dictionary<string, object>>(
                          "AnimeStudioAnime",
                          join => join.HasOne<AnimeStudio>()
                                      .WithMany()
                                      .HasForeignKey("AnimeStudioId")
                                      .OnDelete(DeleteBehavior.Cascade),
                          join => join.HasOne<Anime>()
                                      .WithMany()
                                      .HasForeignKey("AnimeId")
                                      .OnDelete(DeleteBehavior.Cascade)
                      );
            });


            // Configure AnimeStudio entity
            modelBuilder.Entity<AnimeStudio>(entity =>
            {
                entity.HasKey(studio => studio.AnimeStudioId);

                entity.Property(studio => studio.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(studio => studio.Name).IsUnique();
            });

            // Configure Manga entity
            modelBuilder.Entity<Manga>(entity =>
            {
                entity.HasKey(m => m.MangaId);

                entity.Property(m => m.Rank)
                      .HasDefaultValue(0);

                entity.Property(m => m.StartDate)
                      .IsRequired();

                entity.Property(m => m.EndDate)
                      .IsRequired();

                entity.Property(m => m.NumberOfVolumes)
                      .HasDefaultValue(0);

                entity.Property(m => m.NumberOfChapters)
                      .HasDefaultValue(0);

                entity.HasOne(m => m.MediaContent)
                      .WithOne(mc => mc.Manga)
                      .HasForeignKey<Manga>(m => m.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(m => m.MangaAuthors)
                          .WithMany(ma => ma.Mangas)
                          .UsingEntity<Dictionary<string, object>>(
                              "MangaAuthorManga", // Name of the join table
                              join => join.HasOne<MangaAuthor>()
                                          .WithMany()
                                          .HasForeignKey("MangaAuthorId")
                                          .OnDelete(DeleteBehavior.Cascade),
                              join => join.HasOne<Manga>()
                                          .WithMany()
                                          .HasForeignKey("MangaId")
                                          .OnDelete(DeleteBehavior.Cascade)
                          );
            });

            // Configure MangaAuthor entity
            modelBuilder.Entity<MangaAuthor>(entity =>
            {
                entity.HasKey(ma => ma.MangaAuthorId);
                entity.Property(ma => ma.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(ma => ma.Name).IsUnique();
            });

        }
    }
}
