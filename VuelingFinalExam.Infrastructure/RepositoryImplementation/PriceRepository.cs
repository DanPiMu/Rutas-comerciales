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
    public class PriceRepository : IPriceRepository
    {
        private readonly AppDbContext _context;
        public PriceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return await _context.Prices.ToListAsync();
        }
        public async Task<Price> AddAsync(Price price)
        {
            var result = await _context.Prices.AddAsync(price);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
