using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.ApplicationService.Contracts
{
    public interface IDistanceService
    {
        Task<IEnumerable<Distance>> GetAllRoutesAsync();
        Task<Distance> AddDistanceAsync(Distance distance);
    }
}
