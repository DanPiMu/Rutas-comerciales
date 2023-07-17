using Moq;
using VuelingFinalExam.ApplicationService.Implementations;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.UnitTest
{
    [TestClass]
    public class DistanceServiceTests
    {
        private Mock<IDistanceRepository> _distanceRepoMock;
        private DistanceService _distanceService;

        [TestInitialize]
        public void SetUp()
        {
            _distanceRepoMock = new Mock<IDistanceRepository>();
            _distanceService = new DistanceService(_distanceRepoMock.Object);
        }

        [TestMethod]
        public async Task GetAllRoutesAsync()
        {
            var distances = new List<Distance>
    {
        new Distance { OriginPlanetCode = "A", DestinationPlanetCode = "B", LunarYears = 5 },
        new Distance { OriginPlanetCode = "B", DestinationPlanetCode = "C", LunarYears = 7 }
    };

            _distanceRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(distances);

            var result = await _distanceService.GetAllRoutesAsync();

            _distanceRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            CollectionAssert.AreEqual(distances, result.ToList());
        }

        [TestMethod]
        public async Task AddDistanceAsync()
        {
            var distance = new Distance { OriginPlanetCode = "A", DestinationPlanetCode = "B", LunarYears = 5 };
            _distanceRepoMock.Setup(repo => repo.AddAsync(distance)).ReturnsAsync(distance);

            var result = await _distanceService.AddDistanceAsync(distance);

            _distanceRepoMock.Verify(repo => repo.AddAsync(distance), Times.Once);
            Assert.AreEqual(distance, result);
        }

    }

}