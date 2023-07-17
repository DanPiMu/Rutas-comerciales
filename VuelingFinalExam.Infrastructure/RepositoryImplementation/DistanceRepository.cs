using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;
using VuelingFinalExam.Infrastructure.Persistence;

namespace VuelingFinalExam.Infrastructure.RepositoryImplementation
{
    public class DistanceRepository : IDistanceRepository
    {
        private readonly AppDbContext _context;
        public DistanceRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Distance>> GetAllAsync()
        {
            return await _context.Distances.ToListAsync();
        }
        public async Task<Distance> AddAsync(Distance distance)
        {
            var result = await _context.Distances.AddAsync(distance);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
