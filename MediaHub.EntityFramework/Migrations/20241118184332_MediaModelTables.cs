using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaHub.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MediaModelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses");

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
                name: "ActorMovieInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorMovieInfos_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieInfos_MovieInfos_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "MovieInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovieInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieInfoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DirectorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovieInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfos_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovieInfos_MovieInfos_MovieInfoId",
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
                name: "MediaContentGenres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContentGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContentGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaContentGenres_MediaContents_MediaContentId",
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
                name: "AnimeStudioAnimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnimeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnimeStudioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudioAnimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnimes_AnimeStudios_AnimeStudioId",
                        column: x => x.AnimeStudioId,
                        principalTable: "AnimeStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeStudioAnimes_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDeveloperGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameDeveloperId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloperGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDeveloperGames_GameDevelopers_GameDeveloperId",
                        column: x => x.GameDeveloperId,
                        principalTable: "GameDevelopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloperGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatformGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamePlatformId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatformGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlatformGames_GamePlatforms_GamePlatformId",
                        column: x => x.GamePlatformId,
                        principalTable: "GamePlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatformGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePublisherGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GamePublisherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePublisherGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePublisherGames_GamePublishers_GamePublisherId",
                        column: x => x.GamePublisherId,
                        principalTable: "GamePublishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePublisherGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTagGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameTagId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTagGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTagGames_GameTags_GameTagId",
                        column: x => x.GameTagId,
                        principalTable: "GameTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTagGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthorMangas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaAuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthorMangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangaAuthorMangas_MangaAuthors_MangaAuthorId",
                        column: x => x.MangaAuthorId,
                        principalTable: "MangaAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaAuthorMangas_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieInfos_ActorId",
                table: "ActorMovieInfos",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieInfos_MovieInfoId",
                table: "ActorMovieInfos",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_MediaContentId",
                table: "Animes",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudioAnimes_AnimeId",
                table: "AnimeStudioAnimes",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudioAnimes_AnimeStudioId",
                table: "AnimeStudioAnimes",
                column: "AnimeStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudios_Name",
                table: "AnimeStudios",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentStatuses_Name",
                table: "ContentStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovieInfos_DirectorId",
                table: "DirectorMovieInfos",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovieInfos_MovieInfoId",
                table: "DirectorMovieInfos",
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
                name: "IX_GameDeveloperGames_GameDeveloperId",
                table: "GameDeveloperGames",
                column: "GameDeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDeveloperGames_GameId",
                table: "GameDeveloperGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_Name",
                table: "GameDevelopers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatformGames_GameId",
                table: "GamePlatformGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatformGames_GamePlatformId",
                table: "GamePlatformGames",
                column: "GamePlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_Name",
                table: "GamePlatforms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisherGames_GameId",
                table: "GamePublisherGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePublisherGames_GamePublisherId",
                table: "GamePublisherGames",
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
                name: "IX_GameTagGames_GameId",
                table: "GameTagGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTagGames_GameTagId",
                table: "GameTagGames",
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
                name: "IX_MangaAuthorMangas_MangaAuthorId",
                table: "MangaAuthorMangas",
                column: "MangaAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthorMangas_MangaId",
                table: "MangaAuthorMangas",
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
                name: "IX_MediaContentGenres_GenreId",
                table: "MediaContentGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContentGenres_MediaContentId",
                table: "MediaContentGenres",
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
                name: "IX_Serials_MediaContentId",
                table: "Serials",
                column: "MediaContentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serials_MovieInfoId",
                table: "Serials",
                column: "MovieInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses",
                column: "CollectionUserRoleId",
                principalTable: "CollectionUserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses");

            migrationBuilder.DropTable(
                name: "ActorMovieInfos");

            migrationBuilder.DropTable(
                name: "AnimeStudioAnimes");

            migrationBuilder.DropTable(
                name: "DirectorMovieInfos");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "GameDeveloperGames");

            migrationBuilder.DropTable(
                name: "GamePlatformGames");

            migrationBuilder.DropTable(
                name: "GamePublisherGames");

            migrationBuilder.DropTable(
                name: "GameTagGames");

            migrationBuilder.DropTable(
                name: "GenreEvaluations");

            migrationBuilder.DropTable(
                name: "MangaAuthorMangas");

            migrationBuilder.DropTable(
                name: "MediaContentGenres");

            migrationBuilder.DropTable(
                name: "MediaContentPictures");

            migrationBuilder.DropTable(
                name: "MediaInteractionStatuses");

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
                name: "MovieInfos");

            migrationBuilder.DropTable(
                name: "MediaContents");

            migrationBuilder.DropTable(
                name: "MediaContentTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses",
                column: "CollectionUserRoleId",
                principalTable: "CollectionUserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
