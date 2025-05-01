using TheBridge.Data.Entities;
using TheBridge.Dtos;

namespace TheBridge.Repositories.Repos.Contracts
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync(bool asNoTracking = true);
        Task<City> GetCityByIdAsync(Guid id);
        Task CreateCityAsync(CityDto City);
        Task UpdateCityAsync(UpdateCityDto City);
        Task DeleteCityAsync(Guid id);
        Task<IEnumerable<City>> GetCitiesPagedAsync(int pageIndex, int pageSize);
        Task<IEnumerable<City>> GetCitiesByCountryAsync(Guid countryId);
    }
}
