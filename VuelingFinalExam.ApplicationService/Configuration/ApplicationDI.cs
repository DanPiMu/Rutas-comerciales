using Microsoft.Extensions.DependencyInjection;
using VuelingFinalExam.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.ApplicationService.Implementations;
using VuelingFinalExam.ApplicationService.ApiData;

namespace VuelingFinalExam.ApplicationService.Configuration
{
    public static class ApplicationDI
    {
        public static void AddApplicationDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddInfrastructureServices(connectionString);
            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<IPlanetService, PlanetService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<ISpyReportService, SpyReportService>();
            

            services.AddScoped<IDataFetchService, DataFetchService>();


            services.AddHostedService<DataSeederHostedService>();
        }

        public static void CreateDBApplication(this IServiceProvider services)
        {
            services.CreateDB();
        }
    }
}
