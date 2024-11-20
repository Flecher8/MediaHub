using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaHub.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MediaTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionUserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameDevelopers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevelopers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePublishers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DurationInMinutes = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationCollectionUserAccesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecommendationCollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectionUserRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationCollectionUserAccesses", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreEvaluations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecommendationCollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Points = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreEvaluations_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEvaluations_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainPictureLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MediaContentTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContents_MediaContentTypes_MediaContentTypeId",
                        column: x => x.MediaContentTypeId,
                        principalTable: "MediaContentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovieInfo",
                columns: table => new
                {
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieInfo", x => new { x.ActorId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_ActorMovieInfo_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieInfo_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovieInfo",
                columns: table => new
                {
                    DirectorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovieInfo", x => new { x.DirectorId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfo_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfo_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MetacriticRating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PlaytimeHours = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    EsrbRating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfVolumes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentGenre",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentGenre", x => new { x.GenreId, x.MediaContentId });
                    table.ForeignKey(
                        name: "FK_MediaContentGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaContentGenre_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContentPictures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureLink = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContentPictures_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaInteractionStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentStatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecommendationCollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EvaluationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInteractionStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_ContentStatuses_ContentStatusId",
                        column: x => x.ContentStatusId,
                        principalTable: "ContentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaInteractionStatuses_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfSeasons = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serials_MediaContents_MediaContentId",
                        column: x => x.MediaContentId,
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serials_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudioAnime",
                columns: table => new
                {
                    AnimeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnimeStudioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudioAnime", x => new { x.AnimeId, x.AnimeStudioId });
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnime_AnimeStudios_AnimeStudioId",
                        column: x => x.AnimeStudioId,
                        principalTable: "AnimeStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnime_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDeveloperGame",
                columns: table => new
                {
                    GameDeveloperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloperGame", x => new { x.GameDeveloperId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameDeveloperGame_GameDevelopers_GameDeveloperId",
                        column: x => x.GameDeveloperId,
                        principalTable: "GameDevelopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloperGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatformGame",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamePlatformId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatformGame", x => new { x.GameId, x.GamePlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatformGame_GamePlatforms_GamePlatformId",
                        column: x => x.GamePlatformId,
                        principalTable: "GamePlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatformGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublisherGame",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamePublisherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisherGame", x => new { x.GameId, x.GamePublisherId });
                    table.ForeignKey(
                        name: "FK_GamePublisherGame_GamePublishers_GamePublisherId",
                        column: x => x.GamePublisherId,
                        principalTable: "GamePublishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisherGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTagGame",
                columns: table => new
                {
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameTagId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTagGame", x => new { x.GameId, x.GameTagId });
                    table.ForeignKey(
                        name: "FK_GameTagGame_GameTags_GameTagId",
                        column: x => x.GameTagId,
                        principalTable: "GameTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTagGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthorManga",
                columns: table => new
                {
                    MangaAuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthorManga", x => new { x.MangaAuthorId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_MangaAuthorManga_MangaAuthors_MangaAuthorId",
                        column: x => x.MangaAuthorId,
                        principalTable: "MangaAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaAuthorManga_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
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
                name: "MovieInfos");

            migrationBuilder.DropTable(
                name: "MediaContents");

            migrationBuilder.DropTable(
                name: "MediaContentTypes");
        }
    }
}
