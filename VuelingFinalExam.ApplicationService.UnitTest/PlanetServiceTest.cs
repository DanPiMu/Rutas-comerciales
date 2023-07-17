
using Moq;
using VuelingFinalExam.ApplicationService.Implementations;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.UnitTest
{
    [TestClass]
    public class PlanetServiceTest
    {
        private Mock<IPlanetRepository> _planetRepoMock;
        private PlanetService _planetService;

        [TestInitialize]
        public void SetUp()
        {
            _planetRepoMock = new Mock<IPlanetRepository>();
            _planetService = new PlanetService(_planetRepoMock.Object);
        }
        [TestMethod]
        public async Task GetAllPlanetsAsync_ShouldReturnAllPlanets_WhenCalled()
        {
            var planets = new List<Planet>
    {
        new Planet { PlanetName = "Earth", Code = "E", Sector = "S1" },
        new Planet { PlanetName = "Mars", Code = "M", Sector = "S2" }
    };

            _planetRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(planets);

            var result = await _planetService.GetAllPlanetsAsync();

            _planetRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            CollectionAssert.AreEqual(planets, result.ToList());
        }

        [TestMethod]
        public async Task AddPlanetAsync_ShouldReturnAddedPlanet_WhenCalled()
        {
            var planet = new Planet { PlanetName = "Venus", Code = "V", Sector = "S3" };
            _planetRepoMock.Setup(repo => repo.AddAsync(planet)).ReturnsAsync(planet);

            var result = await _planetService.AddPlanetAsync(planet);

            _planetRepoMock.Verify(repo => repo.AddAsync(planet), Times.Once);
            Assert.AreEqual(planet, result);
        }

    }
}
