using App.Application.Repositories;
using App.Application.Services.Abstraction;
using App.Application.Services.Implementation;
using App.Infrastructure.Persistance;
using App.Infrastructure.Persistance.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogServiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            var config = TypeAdapterConfig.GlobalSettings;

            // Scan the assembly for all IRegister implementations
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<ICatalogAppService, CatalogAppService>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
        }
    }
}
