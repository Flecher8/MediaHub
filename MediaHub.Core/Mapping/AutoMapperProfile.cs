using AutoMapper;
using MediaHub.Models.Dtos.GamePlatformDtos;
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
        }
    }
}
