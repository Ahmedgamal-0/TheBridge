using AutoMapper;
using TheBridge.Data.Entities;
using TheBridge.Dtos;
using TheBridge.Repositories.BaseRepositories;
using TheBridge.Repositories.Repos.Contracts;

namespace TheBridge.Repositories.Repos.Implementations
{
    public class CityRepository :ICityRepository
    {
        private readonly IBaseRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public CityRepository(IBaseRepository<City> cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync(bool asNoTracking = true)
        {
            var cities = await _cityRepository.GetAllAsync(asNoTracking);
            return cities;
        }

        public async Task<City> GetCityByIdAsync(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            return city;
        }

        public async Task CreateCityAsync(CityDto city)
        {
            var cityToAdd=_mapper.Map<City>(city);
            await _cityRepository.AddAsync(cityToAdd);
            await _cityRepository.SaveChangesAsync();
        }

        public async Task UpdateCityAsync(UpdateCityDto city)
        {
            var cityData = await _cityRepository.GetByIdAsync(city.Id);
            if (cityData == null) return;
            cityData= _mapper.Map<City>(city);
            await _cityRepository.UpdateAsync(cityData);
            await _cityRepository.SaveChangesAsync();
        }
        public async Task DeleteCityAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
            await _cityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesPagedAsync(int pageIndex, int pageSize)
        {
            var cities = await _cityRepository.GetPagedAsync(pageIndex, pageSize);
            return cities;
        }

        public async Task<IEnumerable<City>> GetCitiesByCountryAsync(Guid countryId)
        {
            var cities = await _cityRepository.GetByConditionAsync(c => c.CountryId == countryId);
            return cities;
        }
    }
}
