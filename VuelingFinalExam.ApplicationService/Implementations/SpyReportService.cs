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
    public class SpyReportService : ISpyReportService
    {

        private readonly ISpyReportRepository _spyReportRepository;

        public SpyReportService(ISpyReportRepository spyReportRepository)
        {
            _spyReportRepository = spyReportRepository;
        }

        public async Task<IEnumerable<SpyReport>> GetAllClientsAsync()
        {
            return await _spyReportRepository.GetAllAsync();
        }


        public async Task<SpyReport> AddClientAsync(SpyReport spyReport)
        {
            return await _spyReportRepository.AddAsync(spyReport);
        }
    }
}
