using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VuelingFinalExam.DomainModel.RepositoryContracts;
using VuelingFinalExam.Infrastructure.Persistence;
using VuelingFinalExam.Infrastructure.RepositoryImplementation;

namespace VuelingFinalExam.Infrastructure.Configuration
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddScoped<IDistanceRepository, DistanceRepository>();
            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<ISpyReportRepository, SpyReportRepository>();
            
            return services;
        }

        public static void CreateDB(this IServiceProvider services)
        {
            var db = services.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
        }
    }
}
