using Microsoft.EntityFrameworkCore;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;
using VuelingFinalExam.Infrastructure.Persistence;

namespace VuelingFinalExam.Infrastructure.RepositoryImplementation
{
    public class SpyReportRepository : ISpyReportRepository
    {
        private readonly AppDbContext _context;
        public SpyReportRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<SpyReport>> GetAllAsync()
        {
            return await _context.SpyReports.ToListAsync();
        }
        public async Task<SpyReport> AddAsync(SpyReport spyReport)
        {
            var result = await _context.SpyReports.AddAsync(spyReport);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SpyReport> GetByPlanetCodeAsync(string planetCode)
        {
            return await _context.SpyReports
                .FirstOrDefaultAsync(s => s.PlanetCode == planetCode);
        }

    }
}
