using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaHub.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudios",
                columns: table => new
                {
                    AnimeStudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudios", x => x.AnimeStudioId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionUserRoles",
                columns: table => new
                {
                    CollectionUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionUserRoles", x => x.CollectionUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ContentStatuses",
                columns: table => new
                {
                    ContentStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentStatuses", x => x.ContentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    GameDeveloperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => x.GameDeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    GamePlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.GamePlatformId);
                });

            migrationBuilder.CreateTable(
                name: "GamePublishers",
                columns: table => new
                {
                    GamePublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublishers", x => x.GamePublisherId);
                });

            migrationBuilder.CreateTable(
                name: "GameTags",
                columns: table => new
                {
                    GameTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTags", x => x.GameTagId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthors",
                columns: table => new
                {
                    MangaAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthors", x => x.MangaAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentTypes",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "MovieInfos",
                columns: table => new
                {
                    MovieInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationInMinutes = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInfos", x => x.MovieInfoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationCollections",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationCollections", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_RecommendationCollections_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContents",
                columns: table => new
                {
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainPictureLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MediaContentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContents", x => x.MediaContentId);
                    table.ForeignKey(
                        name: "FK_MediaContents_MediaContentTypes_MediaContentTypeId",
                        column: x => x.MediaContentTypeId,
                        principalTable: "MediaContentTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovieInfo",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieInfo", x => new { x.ActorId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_ActorMovieInfo_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieInfo_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "MovieInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovieInfo",
                columns: table => new
                {
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovieInfo", x => new { x.DirectorId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfo_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfo_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "MovieInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreEvaluations",
                columns: table => new
                {
                    GenreEvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Points = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    RecommendationCollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEvaluations", x => x.GenreEvaluationId);
                    table.ForeignKey(
                        name: "FK_GenreEvaluations_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEvaluations_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationCollectionUserAccesses",
                columns: table => new
                {
                    UserAccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationCollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationCollectionUserAccesses", x => x.UserAccessId);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                        column: x => x.CollectionUserRoleId,
                        principalTable: "CollectionUserRoles",
                        principalColumn: "CollectionUserRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                    table.ForeignKey(
                        name: "FK_Animes_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Films_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "MovieInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetacriticRating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PlaytimeHours = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    EsrbRating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    MangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfVolumes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.MangaId);
                    table.ForeignKey(
                        name: "FK_Mangas_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentGenre",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentGenre", x => new { x.GenreId, x.MediaContentId });
                    table.ForeignKey(
                        name: "FK_MediaContentGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaContentGenre_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentPictures",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentPictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_MediaContentPictures_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaInteractionStatuses",
                columns: table => new
                {
                    MediaInteractionStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationCollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInteractionStatuses", x => x.MediaInteractionStatusId);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_ContentStatuses_ContentStatusId",
                        column: x => x.ContentStatusId,
                        principalTable: "ContentStatuses",
                        principalColumn: "ContentStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serials",
                columns: table => new
                {
                    SerialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSeasons = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MediaContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serials", x => x.SerialId);
                    table.ForeignKey(
                        name: "FK_Serials_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "MediaContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serials_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "MovieInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudioAnime",
                columns: table => new
                {
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimeStudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudioAnime", x => new { x.AnimeId, x.AnimeStudioId });
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnime_AnimeStudios_AnimeStudioId",
                        column: x => x.AnimeStudioId,
                        principalTable: "AnimeStudios",
                        principalColumn: "AnimeStudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnime_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDeveloperGame",
                columns: table => new
                {
                    GameDeveloperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloperGame", x => new { x.GameDeveloperId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameDeveloperGame_GameDevelopers_GameDeveloperId",
                        column: x => x.GameDeveloperId,
                        principalTable: "GameDevelopers",
                        principalColumn: "GameDeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloperGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatformGame",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamePlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatformGame", x => new { x.GameId, x.GamePlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatformGame_GamePlatforms_GamePlatformId",
                        column: x => x.GamePlatformId,
                        principalTable: "GamePlatforms",
                        principalColumn: "GamePlatformId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatformGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublisherGame",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamePublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisherGame", x => new { x.GameId, x.GamePublisherId });
                    table.ForeignKey(
                        name: "FK_GamePublisherGame_GamePublishers_GamePublisherId",
                        column: x => x.GamePublisherId,
                        principalTable: "GamePublishers",
                        principalColumn: "GamePublisherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisherGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTagGame",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTagGame", x => new { x.GameId, x.GameTagId });
                    table.ForeignKey(
                        name: "FK_GameTagGame_GameTags_GameTagId",
                        column: x => x.GameTagId,
                        principalTable: "GameTags",
                        principalColumn: "GameTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTagGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthorManga",
                columns: table => new
                {
                    MangaAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MangaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthorManga", x => new { x.MangaAuthorId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaAuthorManga_MangaAuthors_MangaAuthorId",
                        column: x => x.MangaAuthorId,
                        principalTable: "MangaAuthors",
                        principalColumn: "MangaAuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaAuthorManga_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieInfo_MovieInfoId",
                table: "ActorMovieInfo",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_MediaContentId",
                table: "Animes",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudioAnime_AnimeStudioId",
                table: "AnimeStudioAnime",
                column: "AnimeStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudios_Name",
                table: "AnimeStudios",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionUserRoles_Name",
                table: "CollectionUserRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentStatuses_Name",
                table: "ContentStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovieInfo_MovieInfoId",
                table: "DirectorMovieInfo",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_Name",
                table: "Evaluations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_MediaContentId",
                table: "Films",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_MovieInfoId",
                table: "Films",
                column: "MovieInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDeveloperGame_GameId",
                table: "GameDeveloperGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_Name",
                table: "GameDevelopers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatformGame_GamePlatformId",
                table: "GamePlatformGame",
                column: "GamePlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_Name",
                table: "GamePlatforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisherGame_GamePublisherId",
                table: "GamePublisherGame",
                column: "GamePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePublishers_Name",
                table: "GamePublishers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_MediaContentId",
                table: "Games",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameTagGame_GameTagId",
                table: "GameTagGame",
                column: "GameTagId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTags_Name",
                table: "GameTags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreEvaluations_GenreId",
                table: "GenreEvaluations",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreEvaluations_RecommendationCollectionId",
                table: "GenreEvaluations",
                column: "RecommendationCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthorManga_MangaId",
                table: "MangaAuthorManga",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthors_Name",
                table: "MangaAuthors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_MediaContentId",
                table: "Mangas",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaContentGenre_MediaContentId",
                table: "MediaContentGenre",
                column: "MediaContentId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContentPictures_MediaContentId",
                table: "MediaContentPictures",
                column: "MediaContentId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContents_MediaContentTypeId",
                table: "MediaContents",
                column: "MediaContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContentTypes_Name",
                table: "MediaContentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaInteractionStatuses_ContentStatusId",
                table: "MediaInteractionStatuses",
                column: "ContentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInteractionStatuses_EvaluationId",
                table: "MediaInteractionStatuses",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInteractionStatuses_MediaContentId",
                table: "MediaInteractionStatuses",
                column: "MediaContentId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaInteractionStatuses_RecommendationCollectionId",
                table: "MediaInteractionStatuses",
                column: "RecommendationCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollections_CreatorUserId",
                table: "RecommendationCollections",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses",
                column: "CollectionUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_RecommendationCollectionId",
                table: "RecommendationCollectionUserAccesses",
                column: "RecommendationCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_UserId",
                table: "RecommendationCollectionUserAccesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Serials_MediaContentId",
                table: "Serials",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serials_MovieInfoId",
                table: "Serials",
                column: "MovieInfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovieInfo");

            migrationBuilder.DropTable(
                name: "AnimeStudioAnime");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DirectorMovieInfo");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "GameDeveloperGame");

            migrationBuilder.DropTable(
                name: "GamePlatformGame");

            migrationBuilder.DropTable(
                name: "GamePublisherGame");

            migrationBuilder.DropTable(
                name: "GameTagGame");

            migrationBuilder.DropTable(
                name: "GenreEvaluations");

            migrationBuilder.DropTable(
                name: "MangaAuthorManga");

            migrationBuilder.DropTable(
                name: "MediaContentGenre");

            migrationBuilder.DropTable(
                name: "MediaContentPictures");

            migrationBuilder.DropTable(
                name: "MediaInteractionStatuses");

            migrationBuilder.DropTable(
                name: "RecommendationCollectionUserAccesses");

            migrationBuilder.DropTable(
                name: "Serials");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AnimeStudios");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "GameDevelopers");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "GamePublishers");

            migrationBuilder.DropTable(
                name: "GameTags");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "MangaAuthors");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ContentStatuses");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "CollectionUserRoles");

            migrationBuilder.DropTable(
                name: "RecommendationCollections");

            migrationBuilder.DropTable(
                name: "MovieInfos");

            migrationBuilder.DropTable(
                name: "MediaContents");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MediaContentTypes");
        }
    }
}
