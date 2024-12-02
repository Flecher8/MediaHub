using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using MediaHub.EntityFramework;
using MediaHub.EntityFramework.Abstract;
using MediaHub.EntityFramework.Repositories;
using MediaHub.EntityFramework.Abstract.IRepositories;
using MediaHub.API.Middlewares;
using MediaHub.Models.Entities;
using MediaHub.Core.Mapping;
using MediaHub.Core.Services.Abstract;
using MediaHub.Core.Services;

namespace MediaHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(typeof(BaseFilterBuilder<>));

            // Repositories
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
            builder.Services.AddScoped<IAnimeStudioRepository, AnimeStudioRepository>();
            builder.Services.AddScoped<ICollectionUserRoleRepository, CollectionUserRoleRepository>();
            builder.Services.AddScoped<IContentStatusRepository, ContentStatusRepository>();
            builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
            builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            builder.Services.AddScoped<IFilmRepository, FilmRepository>();
            builder.Services.AddScoped<IGameDeveloperRepository, GameDeveloperRepository>();
            builder.Services.AddScoped<IGamePlatformRepository, GamePlatformRepository>();
            builder.Services.AddScoped<IGamePublisherRepository, GamePublisherRepository>();
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGameTagRepository, GameTagRepository>();
            builder.Services.AddScoped<IGenreEvaluationRepository, GenreEvaluationRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IMangaAuthorRepository, MangaAuthorRepository>();
            builder.Services.AddScoped<IMangaRepository, MangaRepository>();
            builder.Services.AddScoped<IMediaContentPictureRepository, MediaContentPictureRepository>();
            builder.Services.AddScoped<IMediaContentRepository, MediaContentRepository>();
            builder.Services.AddScoped<IMediaContentTypeRepository, MediaContentTypeRepository>();
            builder.Services.AddScoped<IMediaInteractionStatusRepository, MediaInteractionStatusRepository>();
            builder.Services.AddScoped<IMovieInfoRepository, MovieInfoRepository>();
            builder.Services.AddScoped<IRecommendationCollectionRepository, RecommendationCollectionRepository>();
            builder.Services.AddScoped<IRecommendationCollectionUserAccessRepository, RecommendationCollectionUserAccessRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ISerialRepository, SerialRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Services
            builder.Services.AddScoped<IAnimeStudiosService, AnimeStudiosService>();
            builder.Services.AddScoped<IDirectorsService, DirectorsService>();
            builder.Services.AddScoped<IGameDevelopersService, GameDevelopersService>();
            builder.Services.AddScoped<IGamePlatformsService, GamePlatformsService>();
            builder.Services.AddScoped<IGamePublishersService, GamePublishersService>();
            builder.Services.AddScoped<IGameTagsService, GameTagsService>();
            builder.Services.AddScoped<IMangaAuthorsService, MangaAuthorsService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<DataContext>();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            //builder.Services.AddDbContext<DataContext>(options => {
            //    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("MediaHub.EntityFramework"));
            });

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Add your middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<User>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            // Cors
            app.UseCors("AllowAllHeaders");

            app.Run();
        }
    }
}
