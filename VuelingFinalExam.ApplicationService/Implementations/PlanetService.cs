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
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository) { 
            _planetRepository = planetRepository;
        }
        public async Task<IEnumerable<Planet>> GetAllClientsAsync()
        {
            return await _planetRepository.GetAllAsync();
        }


        public async Task<Planet> AddClientAsync(Planet planet)
        {
            return await _planetRepository.AddAsync(planet);
        }

    }
}
