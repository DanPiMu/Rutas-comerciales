using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.DomainModel.RepositoryContracts
{
    public interface IDistanceRepository
    {
        Task<IEnumerable<Distance>> GetAllAsync();
        Task<Distance> AddAsync(Distance distance);
    }
}
