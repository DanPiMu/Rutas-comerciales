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
    public class PlanetRepository : IPlanetRepository
    {
        private readonly AppDbContext _context;
        public PlanetRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Planet>> GetAllAsync()
        {
            return await _context.Planets.ToListAsync();
        }
        public async Task<Planet> AddAsync(Planet planet)
        {
            var result = await _context.Planets.AddAsync(planet);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
