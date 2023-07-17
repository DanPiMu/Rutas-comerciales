using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.DomainModel.RepositoryContracts
{
    public interface IPriceRepository
    {
        Task<IEnumerable<Price>> GetAllAsync();
        Task<Price> AddAsync(Price price);
        Task<Price> GetBySectorAsync(string sector);
    }
}
