using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.DomainModel.RepositoryContracts
{
    public interface ISpyReportRepository
    {
        Task<IEnumerable<SpyReport>> GetAllAsync();
        Task<SpyReport> AddAsync(SpyReport spyReport);
        Task<SpyReport> GetByPlanetCodeAsync(string planetCode);
    }
}
