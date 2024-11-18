

using Microsoft.EntityFrameworkCore;
using MediaHub.EntityFramewok;
using MediaHub.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using MediaHub.EntityFramewok.Abstract;

namespace MediaHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(typeof(BaseFilterBuilder<>));

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
