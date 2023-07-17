using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.DomainModel.RepositoryContracts
{
    public interface IPlanetRepository
    {
        Task<IEnumerable<Planet>> GetAllAsync();
        Task<Planet> AddAsync(Planet planet);

        Task<Planet> GetByPlanetNameAsync(string planetName);
    }
}
