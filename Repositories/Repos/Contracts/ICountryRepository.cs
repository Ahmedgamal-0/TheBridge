using TheBridge.Data.Entities;
using TheBridge.Dtos;

namespace TheBridge.Repositories.Repos.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync(bool asNoTracking = true);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task CreateCountryAsync(CountryDto Country);
        Task UpdateCountryAsync(UpdateCountryDto Country);
        Task DeleteCountryAsync(Guid id);
        Task<IEnumerable<Country>> GetCountriesPagedAsync(int pageIndex, int pageSize);
    }
}
