using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.ApplicationService.Implementations;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.UnitTest
{
    [TestClass]
    public class SpyReportServiceTest
    {
        private Mock<ISpyReportRepository> _spyReportRepoMock;
        private SpyReportService _spyReportService;

        [TestInitialize]
        public void SetUp()
        {
            _spyReportRepoMock = new Mock<ISpyReportRepository>();
            _spyReportService = new SpyReportService(_spyReportRepoMock.Object);
        }

        [TestMethod]
        public async Task GetAllSpyReportsAsync_ShouldReturnAllSpyReports_WhenCalled()
        {
            var spyReports = new List<SpyReport>
    {
        new SpyReport { PlanetCode = "P1", RebelInfluence = 40 },
        new SpyReport { PlanetCode = "P2", RebelInfluence = 50 }
    };

            _spyReportRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(spyReports);

            var result = await _spyReportService.GetAllSpyReportsAsync();

            _spyReportRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            CollectionAssert.AreEqual(spyReports, result.ToList());
        }

        [TestMethod]
        public async Task AddSpyReportAsync_ShouldReturnAddedSpyReport_WhenCalled()
        {
            var spyReport = new SpyReport { PlanetCode = "P3", RebelInfluence = 60 };
            _spyReportRepoMock.Setup(repo => repo.AddAsync(spyReport)).ReturnsAsync(spyReport);

            var result = await _spyReportService.AddSpyReportAsync(spyReport);

            _spyReportRepoMock.Verify(repo => repo.AddAsync(spyReport), Times.Once);
            Assert.AreEqual(spyReport, result);
        }

    }
}
