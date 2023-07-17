using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.DomainModel.BL
{
    public class RouteCostService
    {
        private readonly IPlanetRepository _planetRepository;
        private readonly IDistanceRepository _distanceRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly ISpyReportRepository _spyReportRepository;

        public RouteCostService(
            IPlanetRepository planetRepository,
            IDistanceRepository distanceRepository,
            IPriceRepository priceRepository,
            ISpyReportRepository spyReportRepository)
        {
            _planetRepository = planetRepository;
            _distanceRepository = distanceRepository;
            _priceRepository = priceRepository;
            _spyReportRepository = spyReportRepository;
        }

        public async Task<RouteCostResult> CalculateRouteCost(string originName, string destinationName)
        {
            var origin = await _planetRepository.GetByPlanetNameAsync(originName);
            var destination = await _planetRepository.GetByPlanetNameAsync(destinationName);

            if (origin == null || destination == null)
            {
                throw new Exception("Invalid origin or destination.");
            }

            var distance = await _distanceRepository.GetByOriginAndDestinationAsync(origin.Code, destination.Code);

            //always ""
            var price = await _priceRepository.GetBySectorAsync(origin.Sector);

            if (distance == null || price == null)
            {
                throw new Exception("Unable to calculate route cost due to missing data.");
            }

            var originSpyReport = await _spyReportRepository.GetByPlanetCodeAsync(origin.Code);
            var destinationSpyReport = await _spyReportRepository.GetByPlanetCodeAsync(destination.Code);

            double basePrice = distance.LunarYears * price.PricesPerLunarDay;

            double originDefenseCost = basePrice * originSpyReport.RebelInfluence / 100.0;
            double destinationDefenseCost = basePrice * destinationSpyReport.RebelInfluence / 100.0;

            double totalRebelInfluence = originSpyReport.RebelInfluence + destinationSpyReport.RebelInfluence;
            double eliteDefenseCost = 0;

            if (totalRebelInfluence > 40)
            {
                eliteDefenseCost = basePrice * (totalRebelInfluence - 40) / 100.0;
            }

            double totalAmount = basePrice + originDefenseCost + destinationDefenseCost + eliteDefenseCost;

            return new RouteCostResult
            {
                TotalAmount = totalAmount,
                PricesPerLunarDay = price.PricesPerLunarDay,
                Taxes = new RouteCostTaxes
                {
                    OriginDefenseCost = originDefenseCost,
                    DestinationDefenseCost = destinationDefenseCost,
                    EliteDefenseCost = eliteDefenseCost
                }
            };
        }
        public class RouteCostResult
        {
            public double TotalAmount { get; set; }
            public double PricesPerLunarDay { get; set; }
            public RouteCostTaxes Taxes { get; set; }
        }

        public class RouteCostTaxes
        {
            public double OriginDefenseCost { get; set; }
            public double DestinationDefenseCost { get; set; }
            public double EliteDefenseCost { get; set; }
        }
    }
}
