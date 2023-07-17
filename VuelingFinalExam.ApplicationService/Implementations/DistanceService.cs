using VuelingFinalExam.ApplicationService.Contracts;
using VuelingFinalExam.DomainModel.Entites;
using VuelingFinalExam.DomainModel.RepositoryContracts;

namespace VuelingFinalExam.ApplicationService.Implementations
{
    public class DistanceService : IDistanceService
    {
        private readonly IDistanceRepository _distanceRepository;

        public DistanceService(IDistanceRepository distanceRepository)
        {
            _distanceRepository = distanceRepository;
        }

        public async Task<IEnumerable<Distance>> GetAllRoutesAsync()
        {
            return await _distanceRepository.GetAllAsync();
        }

        public async Task<Distance> AddDistanceAsync(Distance distance)
        {
            return await _distanceRepository.AddAsync(distance);
        }
    }
}
