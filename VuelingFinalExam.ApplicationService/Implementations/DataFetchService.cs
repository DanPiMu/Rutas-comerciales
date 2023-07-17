using Newtonsoft.Json;
using Serilog;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.ApplicationService.Implementations
{
    public class DataFetchService : IDataFetchService
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string PlanetsApiUrl = "https://otd-exams-data.vueling.app/sindicate/planets.json";
        private const string DistancesApiUrl = "https://otd-exams-data.vueling.app/sindicate/distances.json";
        private const string PricesApiUrl = "https://otd-exams-data.vueling.app/empire/prices.json";
        private const string SpyReportApiUrl = "https://otd-exams-data.vueling.app/empire/spyreport.json";


        public async Task<IEnumerable<Planet>> FetchPlanetsFromApiAsync()
        {
            try
            {
                var response = await HttpClient.GetStringAsync(PlanetsApiUrl);
                var planets = JsonConvert.DeserializeObject<List<Planet>>(response);
                return planets;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching Planet: {ex.Message}");
                return Enumerable.Empty<Planet>();
            }
            /* try
             {
                 var response = await HttpClient.GetStringAsync(PlanetsApiUrl);
                 var planetData = JsonConvert.DeserializeObject<PlanetData>(response);
                 return planetData.Planets;
             }
             catch (Exception ex)
             {
                 Log.Error($"An error occurred while fetching Planet: {ex.Message}");
                 return Enumerable.Empty<Planet>();
             }*/
        }
        public async Task<IEnumerable<Distance>> FetchDistancesFromApiAsync()
        {
            /*try
            {
                var response = await HttpClient.GetStringAsync(DistancesApiUrl);
                var distanceData = JsonConvert.DeserializeObject<DistanceData>(response);
                return distanceData.Distances;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred while fetching distance: {ex.Message}");
                return Enumerable.Empty<Distance>();
            }*/
            try
            {
                var response = await HttpClient.GetStringAsync(DistancesApiUrl);
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
                var response = await HttpClient.GetStringAsync(PricesApiUrl);
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
                var response = await HttpClient.GetStringAsync(SpyReportApiUrl);
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
    public class PlanetData
    {
        public List<Planet> Planets { get; set; }
    }

    public class DistanceData
    {
        public List<Distance> Distances { get; set; }
    }
    public class PriceData
    {
        public List<Price> Price { get; set; }
    }

    public class SpyReportData
    {
        public List<SpyReport> SpyReport { get; set; }
    }
}
