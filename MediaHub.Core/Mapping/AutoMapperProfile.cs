﻿using AutoMapper;
using MediaHub.Models.Dtos.AnimeStudioDtos;
using MediaHub.Models.Dtos.DirectorDtos;
using MediaHub.Models.Dtos.GameDeveloperDtos;
using MediaHub.Models.Dtos.GamePlatformDtos;
using MediaHub.Models.Dtos.GamePublisherDtos;
using MediaHub.Models.Dtos.GameTagDtos;
using MediaHub.Models.Dtos.MangaAuthorDtos;
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

            // AnimeStudio mappings
            CreateMap<CreateAnimeStudioDto, AnimeStudio>();
            CreateMap<UpdateAnimeStudioDto, AnimeStudio>();
            CreateMap<AnimeStudio, AnimeStudioDto>();

            // MangaAuthor mappings
            CreateMap<CreateMangaAuthorDto, MangaAuthor>();
            CreateMap<UpdateMangaAuthorDto, MangaAuthor>();
            CreateMap<MangaAuthor, MangaAuthorDto>();

            // Director mappings
            CreateMap<CreateDirectorDto, Director>();
            CreateMap<UpdateDirectorDto, Director>();
            CreateMap<Director, DirectorDto>();
        }
    }
}
