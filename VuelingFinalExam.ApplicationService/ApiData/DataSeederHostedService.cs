using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.ApiData
{
    public class DataSeederHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSeederHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dataFetchService = scope.ServiceProvider.GetRequiredService<IDataFetchService>();

                var distanceRepository = scope.ServiceProvider.GetRequiredService<IDistanceRepository>();
                var planetRepository = scope.ServiceProvider.GetRequiredService<IPlanetRepository>();
                var priceRepository = scope.ServiceProvider.GetRequiredService<IPriceRepository>();
                var spyReportRepository = scope.ServiceProvider.GetRequiredService<ISpyReportRepository>();

                var distances = await dataFetchService.FetchDistancesFromApiAsync();
                var planets = await dataFetchService.FetchPlanetsFromApiAsync();
                var prices = await dataFetchService.FetchPriceFromApiAsync();
                var spyReports = await dataFetchService.FetchSpyReportsFromApiAsync();

                var existingDistances = await distanceRepository.GetAllAsync();
                var existingPlanets = await planetRepository.GetAllAsync();
                var existingPrices = await priceRepository.GetAllAsync();
                var existingSpyReports = await spyReportRepository.GetAllAsync();

                var newDistances = distances.Where(c => !existingDistances.Any(ec => ec.OriginPlanetCode == c.OriginPlanetCode));
                var newPlanets = planets.Where(p => !existingPlanets.Any(ep => ep.PlanetName == p.PlanetName));
                var newPrices = prices.Where(c => !existingPrices.Any(ec => ec.Sector == c.Sector));
                var newSpyReports = spyReports.Where(p => !existingSpyReports.Any(ep => ep.PlanetCode == p.PlanetCode));


                foreach (var distance in newDistances)
                {
                    await distanceRepository.AddAsync(distance);
                }

                foreach (var planet in newPlanets)
                {
                    await planetRepository.AddAsync(planet);
                }
                foreach (var price in newPrices)
                {
                    await priceRepository.AddAsync(price);
                }

                foreach (var spyReport in newSpyReports)
                {
                    await spyReportRepository.AddAsync(spyReport);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
