using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.Implementations
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;
        public PriceService(IPriceRepository priceRepository) 
        {
            _priceRepository = priceRepository;
        }

        public async Task<IEnumerable<Price>> GetAllPricesAsync()
        {
            return await _priceRepository.GetAllAsync();
        }


        public async Task<Price> AddPriceAsync(Price price)
        {
            return await _priceRepository.AddAsync(price);
        }

    }
}
