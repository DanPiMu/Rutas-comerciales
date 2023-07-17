using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.ApplicationService.Implementations
{
    public class DataFetchService : IDataFetchService
    {
        private readonly IConfiguration _configuration;

        public DataFetchService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private static readonly HttpClient HttpClient = new HttpClient();
       

        public async Task<IEnumerable<Planet>> FetchPlanetsFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(_configuration["ApiUrls:PlanetsApiUrl"]);
                var planets = JsonConvert.DeserializeObject<List<Planet>>(response);
                return planets;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching Planet: {ex.Message}");
                return Enumerable.Empty<Planet>();
            }
            
        }
        public async Task<IEnumerable<Distance>> FetchDistancesFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(_configuration["ApiUrls:DistancesApiUrl"]);
                var distanceData = JsonConvert.DeserializeObject<Dictionary<string, List<DistanceItem>>>(response);

                var distances = new List<Distance>();
                foreach (var entry in distanceData)
                {
                    foreach (var item in entry.Value)
                    {
                        distances.Add(new Distance
                        {
                            OriginPlanetCode = entry.Key,
                            DestinationPlanetCode = item.Code,
                            LunarYears = item.LunarYears
                        });
                    }
                }

                return distances;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching distance: {ex.Message}");
                return Enumerable.Empty<Distance>();
            }
        }
        public async Task<IEnumerable<Price>> FetchPriceFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(_configuration["ApiUrls:PricesApiUrl"]);
                var prices = JsonConvert.DeserializeObject<List<Price>>(response);
                return prices;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching price: {ex.Message}");
                return Enumerable.Empty<Price>();
            }
        }
        public async Task<IEnumerable<SpyReport>> FetchSpyReportsFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(_configuration["ApiUrls:SpyReportApiUrl"]);
                var spyReports = JsonConvert.DeserializeObject<List<SpyReport>>(response);
                return spyReports;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching spy report: {ex.Message}");
                return Enumerable.Empty<SpyReport>();
            }
        }

    }
}
