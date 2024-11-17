using MediaHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.EntityFramewok
{
    public class DataContext : IdentityDbContext<User, Role, string>
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public DbSet<CollectionUserRole> CollectionUserRoles { get; set; }
        public DbSet<ContentStatus> ContentStatuses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreEvaluation> GenreEvaluations { get; set; }
        public DbSet<MediaContent> MediaContents { get; set; }
        public DbSet<MediaContentGenre> MediaContentGenres { get; set; }
        public DbSet<MediaContentPicture> MediaContentPictures { get; set; }
        public DbSet<MediaContentType> MediaContentTypes { get; set; }
        public DbSet<MediaInteractionStatus> MediaInteractionStatuses { get; set; }
        public DbSet<RecommendationCollection> RecommendationCollections { get; set; }
        public DbSet<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<MovieInfo> MovieInfos { get; set; }
        public DbSet<DirectorMovieInfo> DirectorMovieInfos { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<ActorMovieInfo> ActorMovieInfos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GamePlatformGame> GamePlatformGames { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<GameDeveloperGame> GameDeveloperGames { get; set; }
        public DbSet<GamePublisher> GamePublishers { get; set; }
        public DbSet<GamePublisherGame> GamePublisherGames { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<GameTagGame> GameTagGames { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeStudio> AnimeStudios { get; set; }
        public DbSet<AnimeStudioAnime> AnimeStudioAnimes { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<MangaAuthor> MangaAuthors { get; set; }
        public DbSet<MangaAuthorManga> MangaAuthorMangas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure CollectionUserRole entity
            modelBuilder.Entity<CollectionUserRole>(entity =>
            {
                entity.HasKey(cr => cr.Id);

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
                entity.HasKey(cs => cs.Id);

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
                entity.HasKey(ev => ev.Id);

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
                entity.HasKey(g => g.Id);

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

                entity.HasMany(g => g.MediaContentGenres)
                      .WithOne(mcg => mcg.Genre)
                      .HasForeignKey(mcg => mcg.GenreId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure GenreEvaluation entity
            modelBuilder.Entity<GenreEvaluation>(entity =>
            {
                entity.HasKey(ge => ge.Id);

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
                entity.HasKey(mc => mc.Id);

                entity.Property(mc => mc.Title).IsRequired().HasMaxLength(200);

                entity.Property(mc => mc.Description).HasMaxLength(10000);

                entity.Property(mc => mc.Rating).HasDefaultValue(0);

                entity.Property(mc => mc.ReleaseDate).IsRequired();

                entity.Property(mc => mc.MainPictureLink).HasMaxLength(500);

                entity.HasMany(mc => mc.MediaInteractionStatuses)
                      .WithOne(mis => mis.MediaContent)
                      .HasForeignKey(mis => mis.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(mc => mc.MediaContentGenres)
                      .WithOne(mcg => mcg.MediaContent)
                      .HasForeignKey(mcg => mcg.MediaContentId)
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

            });

            // Configure MediaContentGenre entity
            modelBuilder.Entity<MediaContentGenre>(entity =>
            {
                entity.HasKey(mcg => mcg.Id);
                entity.HasOne(mcg => mcg.MediaContent)
                      .WithMany(mc => mc.MediaContentGenres)
                      .HasForeignKey(mcg => mcg.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(mcg => mcg.Genre)
                      .WithMany(g => g.MediaContentGenres)
                      .HasForeignKey(mcg => mcg.GenreId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure MediaContentPicture entity
            modelBuilder.Entity<MediaContentPicture>(entity =>
            {
                entity.HasKey(mcp => mcp.Id);

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
                entity.HasKey(mct => mct.Id);

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
                entity.HasKey(mis => mis.Id);

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
                entity.HasKey(rc => rc.Id);

                entity.HasOne(rc => rc.Creator)
                      .WithMany(u => u.RecommendationCollections)
                      .HasForeignKey(rc => rc.CreatorId)
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
                entity.HasKey(rcua => rcua.Id);

                entity.HasOne(rcua => rcua.User)
                      .WithMany(u => u.RecommendationCollectionUserAccess)
                      .HasForeignKey(rcua => rcua.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rcua => rcua.RecommendationCollection)
                      .WithMany(rc => rc.RecommendationCollectionUserAccesses)
                      .HasForeignKey(rcua => rcua.RecommendationCollectionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rcua => rcua.CollectionUserRole)
                      .WithMany(cr => cr.RecommendationCollectionUserAccesses)
                      .HasForeignKey(rcua => rcua.CollectionUserRoleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Configure Film entity
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(f => f.Id);

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
                entity.HasKey(s => s.Id);

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
                entity.HasKey(mi => mi.Id);
                entity.Property(mi => mi.DurationInMinutes).HasDefaultValue(0);

                entity.HasOne(mi => mi.Film)
                      .WithOne(f => f.MovieInfo)
                      .HasForeignKey<Film>(f => f.MovieInfoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mi => mi.Serial)
                      .WithOne(s => s.MovieInfo)
                      .HasForeignKey<Serial>(s => s.MovieInfoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure DirectorMovieInfo entity
            modelBuilder.Entity<DirectorMovieInfo>(entity =>
            {
                entity.HasKey(dmi => dmi.Id);

                entity.HasOne(dmi => dmi.MovieInfo)
                      .WithMany(mi => mi.DirectorMovieInfos)
                      .HasForeignKey(dmi => dmi.MovieInfoId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(dmi => dmi.Director)
                      .WithMany(d => d.DirectorMovieInfos)
                      .HasForeignKey(dmi => dmi.DirectorId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Director entity
            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(d => d.DirectorMovieInfos)
                      .WithOne(dmi => dmi.Director)
                      .HasForeignKey(dmi => dmi.DirectorId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure ActorMovieInfo entity
            modelBuilder.Entity<ActorMovieInfo>(entity =>
            {
                entity.HasKey(ami => ami.Id);

                entity.HasOne(ami => ami.MovieInfo)
                      .WithMany(mi => mi.ActorMovieInfos)
                      .HasForeignKey(ami => ami.MovieInfoId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ami => ami.Actor)
                      .WithMany(a => a.ActorMovieInfos)
                      .HasForeignKey(ami => ami.ActorId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Actor entity
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasMany(a => a.ActorMovieInfos)
                      .WithOne(ami => ami.Actor)
                      .HasForeignKey(ami => ami.ActorId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Game entity
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.MetacriticRating).HasDefaultValue(0);

                entity.Property(g => g.PlaytimeHours).HasDefaultValue(0);

                entity.Property(g => g.EsrbRating).HasDefaultValue(0);

                entity.HasOne(g => g.MediaContent)
                      .WithOne(mc => mc.Game)
                      .HasForeignKey<Game>(g => g.MediaContentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(g => g.GamePlatformGames)
                      .WithOne(gpg => gpg.Game)
                      .HasForeignKey(gpg => gpg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(g => g.GameDeveloperGames)
                      .WithOne(gdg => gdg.Game)
                      .HasForeignKey(gdg => gdg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(g => g.GamePublisherGames)
                      .WithOne(gpg => gpg.Game)
                      .HasForeignKey(gpg => gpg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(g => g.GameTagGames)
                      .WithOne(gtg => gtg.Game)
                      .HasForeignKey(gtg => gtg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure GamePlatform entity
            modelBuilder.Entity<GamePlatform>(entity =>
            {
                entity.HasKey(gp => gp.Id);

                entity.Property(gp => gp.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gp => gp.Name).IsUnique();

                entity.HasMany(gp => gp.GamePlatformGames)
                      .WithOne(gpg => gpg.GamePlatform)
                      .HasForeignKey(gpg => gpg.GamePlatformId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure GamePlatformGame entity (many-to-many)
            modelBuilder.Entity<GamePlatformGame>(entity =>
            {
                entity.HasKey(gpg => gpg.Id);

                entity.HasOne(gpg => gpg.Game)
                      .WithMany(g => g.GamePlatformGames)
                      .HasForeignKey(gpg => gpg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(gpg => gpg.GamePlatform)
                      .WithMany(gp => gp.GamePlatformGames)
                      .HasForeignKey(gpg => gpg.GamePlatformId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure GameDeveloper entity
            modelBuilder.Entity<GameDeveloper>(entity =>
            {
                entity.HasKey(gd => gd.Id);

                entity.Property(gd => gd.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gd => gd.Name).IsUnique();

                entity.HasMany(gd => gd.GameDeveloperGames)
                      .WithOne(gdg => gdg.GameDeveloper)
                      .HasForeignKey(gdg => gdg.GameDeveloperId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure GameDeveloperGame entity (many-to-many)
            modelBuilder.Entity<GameDeveloperGame>(entity =>
            {
                entity.HasKey(gdg => gdg.Id);

                entity.HasOne(gdg => gdg.Game)
                      .WithMany(g => g.GameDeveloperGames)
                      .HasForeignKey(gdg => gdg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(gdg => gdg.GameDeveloper)
                      .WithMany(gd => gd.GameDeveloperGames)
                      .HasForeignKey(gdg => gdg.GameDeveloperId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure GamePublisher entity
            modelBuilder.Entity<GamePublisher>(entity =>
            {
                entity.HasKey(gp => gp.Id);

                entity.Property(gp => gp.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gp => gp.Name).IsUnique();

                entity.HasMany(gp => gp.GamePublisherGames)
                      .WithOne(gpg => gpg.GamePublisher)
                      .HasForeignKey(gpg => gpg.GamePublisherId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure GamePublisherGame entity (many-to-many)
            modelBuilder.Entity<GamePublisherGame>(entity =>
            {
                entity.HasKey(gpg => gpg.Id);

                entity.HasOne(gpg => gpg.Game)
                      .WithMany(g => g.GamePublisherGames)
                      .HasForeignKey(gpg => gpg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(gpg => gpg.GamePublisher)
                      .WithMany(gp => gp.GamePublisherGames)
                      .HasForeignKey(gpg => gpg.GamePublisherId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure GameTag entity
            modelBuilder.Entity<GameTag>(entity =>
            {
                entity.HasKey(gt => gt.Id);

                entity.Property(gt => gt.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(gt => gt.Name).IsUnique();

                entity.HasMany(gt => gt.GameTagGames)
                      .WithOne(gtg => gtg.GameTag)
                      .HasForeignKey(gtg => gtg.GameTagId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure GameTagGame entity (many-to-many)
            modelBuilder.Entity<GameTagGame>(entity =>
            {
                entity.HasKey(gtg => gtg.Id);

                entity.HasOne(gtg => gtg.Game)
                      .WithMany(g => g.GameTagGames)
                      .HasForeignKey(gtg => gtg.GameId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(gtg => gtg.GameTag)
                      .WithMany(gt => gt.GameTagGames)
                      .HasForeignKey(gtg => gtg.GameTagId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Anime entity
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.HasKey(a => a.Id);

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

                entity.HasMany(a => a.AnimeStudioAnimes)
                      .WithOne(asa => asa.Anime)
                      .HasForeignKey(asa => asa.AnimeId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure AnimeStudio entity
            modelBuilder.Entity<AnimeStudio>(entity =>
            {
                entity.HasKey(studio => studio.Id);

                entity.Property(studio => studio.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(studio => studio.Name).IsUnique();

                entity.HasMany(studio => studio.AnimeStudiosAnimes)
                      .WithOne(asa => asa.AnimeStudio)
                      .HasForeignKey(asa => asa.AnimeStudioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure AnimeStudioAnime (many-to-many join table)
            modelBuilder.Entity<AnimeStudioAnime>(entity =>
            {
                entity.HasKey(asa => asa.Id);

                entity.HasOne(asa => asa.Anime)
                      .WithMany(a => a.AnimeStudioAnimes)
                      .HasForeignKey(asa => asa.AnimeId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(asa => asa.AnimeStudio)
                      .WithMany(studio => studio.AnimeStudiosAnimes)
                      .HasForeignKey(asa => asa.AnimeStudioId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure Manga entity
            modelBuilder.Entity<Manga>(entity =>
            {
                entity.HasKey(m => m.Id);

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

                entity.HasMany(m => m.MangaAuthorMangas)
                      .WithOne(mam => mam.Manga)
                      .HasForeignKey(mam => mam.MangaId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Configure MangaAuthor entity
            modelBuilder.Entity<MangaAuthor>(entity =>
            {
                entity.HasKey(ma => ma.Id);
                entity.Property(ma => ma.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(ma => ma.Name).IsUnique();

                entity.HasMany(ma => ma.MangaAuthorMangas)
                      .WithOne(mam => mam.MangaAuthor)
                      .HasForeignKey(mam => mam.MangaAuthorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure MangaAuthorManga (many-to-many join table)
            modelBuilder.Entity<MangaAuthorManga>(entity =>
            {
                entity.HasKey(mam => mam.Id);

                entity.HasOne(mam => mam.Manga)
                      .WithMany(m => m.MangaAuthorMangas)
                      .HasForeignKey(mam => mam.MangaId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mam => mam.MangaAuthor)
                      .WithMany(ma => ma.MangaAuthorMangas)
                      .HasForeignKey(mam => mam.MangaAuthorId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
