using VuelingFinalExam.DomainModel.Entites;

namespace VuelingFinalExam.ApplicationService.Contracts
{
    public interface IDataFetchService
    {
        Task<IEnumerable<Planet>> FetchPlanetsFromApiAsync();
        Task<IEnumerable<Distance>> FetchDistancesFromApiAsync();
        Task<IEnumerable<Price>> FetchPriceFromApiAsync();
        Task<IEnumerable<SpyReport>> FetchSpyReportsFromApiAsync();
    }
}
