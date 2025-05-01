using AutoMapper;
using TheBridge.Data.Entities;
using TheBridge.Dtos;
using TheBridge.Repositories.BaseRepositories;
using TheBridge.Repositories.Repos.Contracts;

namespace TheBridge.Repositories.Repos.Implementations
{
    public class CountryRepository:ICountryRepository
    {
        private readonly IBaseRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public CountryRepository(IBaseRepository<Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync(bool asNoTracking = true)
        {
            var countries = await _countryRepository.GetAllAsync(asNoTracking);
            return countries;
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            return country;
        }

        public async Task CreateCountryAsync(CountryDto country)
        {
            var countryToAdd=_mapper.Map<Country>(country);
            await _countryRepository.AddAsync(countryToAdd);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(UpdateCountryDto Country)
        {
            var country = await _countryRepository.GetByIdAsync(Country.Id);
            if (country == null) return;
            country = _mapper.Map<Country>(Country);
            await _countryRepository.UpdateAsync(country);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
            await _countryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetCountriesPagedAsync(int pageIndex, int pageSize)
        {
            var countries = await _countryRepository.GetPagedAsync(pageIndex, pageSize);
            return countries;
        }
    }
}
