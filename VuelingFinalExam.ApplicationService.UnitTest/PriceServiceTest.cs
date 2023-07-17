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
    public class PriceServiceTest
    {
        private Mock<IPriceRepository> _priceRepoMock;
        private PriceService _priceService;

        [TestInitialize]
        public void SetUp()
        {
            _priceRepoMock = new Mock<IPriceRepository>();
            _priceService = new PriceService(_priceRepoMock.Object);
        }

        [TestMethod]
        public async Task GetAllPricesAsync_ShouldReturnAllPrices_WhenCalled()
        {
            var prices = new List<Price>
    {
        new Price { Sector = "S1", PricesPerLunarDay = 100.00 },
        new Price { Sector = "S2", PricesPerLunarDay = 200.00 }
    };

            _priceRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(prices);

            var result = await _priceService.GetAllPricesAsync();

            _priceRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            CollectionAssert.AreEqual(prices, result.ToList());
        }

        [TestMethod]
        public async Task AddPriceAsync_ShouldReturnAddedPrice_WhenCalled()
        {
            var price = new Price { Sector = "S3", PricesPerLunarDay = 300.00 };
            _priceRepoMock.Setup(repo => repo.AddAsync(price)).ReturnsAsync(price);

            var result = await _priceService.AddPriceAsync(price);

            _priceRepoMock.Verify(repo => repo.AddAsync(price), Times.Once);
            Assert.AreEqual(price, result);
        }

    }
}
