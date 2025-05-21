using AutoMapper;
using MediaHub.Models.Dtos.ActorDtos;
using MediaHub.Models.Dtos.AnimeDtos;
using MediaHub.Models.Dtos.AnimeStudioDtos;
using MediaHub.Models.Dtos.CollectionUserRoleDtos;
using MediaHub.Models.Dtos.ContentStatusDtos;
using MediaHub.Models.Dtos.DirectorDtos;
using MediaHub.Models.Dtos.EvaluationDtos;
using MediaHub.Models.Dtos.FilmDtos;
using MediaHub.Models.Dtos.GameDeveloperDtos;
using MediaHub.Models.Dtos.GameDtos;
using MediaHub.Models.Dtos.GamePlatformDtos;
using MediaHub.Models.Dtos.GamePublisherDtos;
using MediaHub.Models.Dtos.GameTagDtos;
using MediaHub.Models.Dtos.GenreDtos;
using MediaHub.Models.Dtos.MangaAuthorDtos;
using MediaHub.Models.Dtos.MangaDtos;
using MediaHub.Models.Dtos.MediaContentDtos;
using MediaHub.Models.Dtos.MediaContentTypeDtos;
using MediaHub.Models.Dtos.MediaInteractionStatusDtos;
using MediaHub.Models.Dtos.MovieInfoDtos;
using MediaHub.Models.Dtos.PictureLinkDtos;
using MediaHub.Models.Dtos.RecommendationCollectionDtos;
using MediaHub.Models.Dtos.RecommendationCollectionUserAccessDtos;
using MediaHub.Models.Dtos.SerialDtos;
using MediaHub.Models.Dtos.UserDtos;
using MediaHub.Models.Entities;

namespace MediaHub.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // GamePlatform mappings
            CreateMap<CreateGamePlatformDto, GamePlatform>();
            CreateMap<UpdateGamePlatformDto, GamePlatform>();
            CreateMap<GamePlatform, GamePlatformDto>();

            // GameDeveloper mappings
            CreateMap<CreateGameDeveloperDto, GameDeveloper>();
            CreateMap<UpdateGameDeveloperDto, GameDeveloper>();
            CreateMap<GameDeveloper, GameDeveloperDto>();

            // GamePublisher mappings
            CreateMap<CreateGamePublisherDto, GamePublisher>();
            CreateMap<UpdateGamePublisherDto, GamePublisher>();
            CreateMap<GamePublisher, GamePublisherDto>();

            // GameTag mappings
            CreateMap<CreateGameTagDto, GameTag>();
            CreateMap<UpdateGameTagDto, GameTag>();
            CreateMap<GameTag, GameTagDto>();

            // Director mappings
            CreateMap<CreateDirectorDto, Director>();
            CreateMap<UpdateDirectorDto, Director>();
            CreateMap<Director, DirectorDto>();

            // Actor mappings
            CreateMap<CreateActorDto, Actor>();
            CreateMap<UpdateActorDto, Actor>();
            CreateMap<Actor, ActorDto>();

            // Genres mappings
            CreateMap<Genre, GenreDto>();

            // MediaContentPictures mappings
            CreateMap<MediaContentPicture, MediaContentPictureDto>();

            // MediaContentType mappings
            CreateMap<CreateMediaContentTypeDto, MediaContentType>();
            CreateMap<UpdateMediaContentTypeDto, MediaContentType>();
            CreateMap<MediaContentType, MediaContentTypeDto>();

            // MediaContentType mappings
            CreateMap<CreateMediaContentDto, MediaContentType>();
            CreateMap<UpdateMediaContentDto, MediaContentType>();
            CreateMap<MediaContent, MediaContentDto>()
                .ForMember(d => d.Genres,
                           o => o.MapFrom(src => src.Genres))
                .ForMember(d => d.PictureLinks,
                           o => o.MapFrom(src => src.MediaContentPictures))
                .ForMember(d => d.MediaContentType,
                           o => o.MapFrom(src => src.MediaContentType));

            // ContentStatus mappings
            CreateMap<CreateContentStatusDto, ContentStatus>();
            CreateMap<UpdateContentStatusDto, ContentStatus>();
            CreateMap<ContentStatus, ContentStatusDto>();

            // AnimeStudio mappings
            CreateMap<CreateAnimeStudioDto, AnimeStudio>();
            CreateMap<UpdateAnimeStudioDto, AnimeStudio>();
            CreateMap<AnimeStudio, AnimeStudioDto>();

            // Anime mappings
            CreateMap<Anime, AnimeDto>()
                .ForMember(d => d.MediaContent,
                           o => o.MapFrom(src => src.MediaContent))
                .ForMember(d => d.AnimeStudios,
                           o => o.MapFrom(src => src.AnimeStudios));

            // MangaAuthor mappings
            CreateMap<CreateMangaAuthorDto, MangaAuthor>();
            CreateMap<UpdateMangaAuthorDto, MangaAuthor>();
            CreateMap<MangaAuthor, MangaAuthorDto>();

            // Manga mappings
            CreateMap<Manga, MangaDto>()
                .ForMember(d => d.MediaContent,
                           o => o.MapFrom(src => src.MediaContent))
                .ForMember(d => d.MangaAuthors,
                           o => o.MapFrom(src => src.MangaAuthors));

            // MovieInfo mappings
            CreateMap<MovieInfo, MovieInfoDto>()
                .ForMember(d => d.Actors, o => o.MapFrom(src => src.Actors))
                .ForMember(d => d.Directors, o => o.MapFrom(src => src.Directors));

            // Film mappings
            CreateMap<Film, FilmDto>()
                .ForMember(d => d.MediaContent, o => o.MapFrom(src => src.MediaContent))
                .ForMember(d => d.MovieInfo, o => o.MapFrom(src => src.MovieInfo));

            // Serial mappings
            CreateMap<Serial, SerialDto>()
                .ForMember(d => d.MediaContent, o => o.MapFrom(s => s.MediaContent))
                .ForMember(d => d.MovieInfo, o => o.MapFrom(s => s.MovieInfo));

            // Game mappings
            CreateMap<Game, GameDto>()
                .ForMember(d => d.MediaContent, o => o.MapFrom(s => s.MediaContent))
                .ForMember(d => d.GamePlatforms, o => o.MapFrom(s => s.GamePlatforms))
                .ForMember(d => d.GameDevelopers, o => o.MapFrom(s => s.GameDevelopers))
                .ForMember(d => d.GamePublishers, o => o.MapFrom(s => s.GamePublishers))
                .ForMember(d => d.GameTags, o => o.MapFrom(s => s.GameTags));

            // User mappings
            CreateMap<User, UserDto>();

            // RecommendationCollection mappings
            CreateMap<RecommendationCollection, RecommendationCollectionDto>();

            // CollectionUserRole mappings
            CreateMap<CollectionUserRole, CollectionUserRoleDto>();

            // RecommendationCollectionUserAccess mappings
            CreateMap<RecommendationCollectionUserAccess, RecommendationCollectionUserAccessDto>()
                .ForMember(d => d.User, o => o.MapFrom(src => src.User))
                .ForMember(d => d.Role, o => o.MapFrom(src => src.CollectionUserRole));

            // Evaluation mappings
            CreateMap<Evaluation, EvaluationDto>();

            // MediaInteractionStatus mappings
            CreateMap<MediaInteractionStatus, MediaInteractionStatusDto>()
                .ForMember(d => d.MediaContent, o => o.MapFrom(src => src.MediaContent))
                .ForMember(d => d.ContentStatus, o => o.MapFrom(src => src.ContentStatus))
                .ForMember(d => d.Evaluation, o => o.MapFrom(src => src.Evaluation))
                .ForMember(d => d.RecommendationCollection,
                            o => o.MapFrom(src => src.RecommendationCollection));
        }
    }
}
