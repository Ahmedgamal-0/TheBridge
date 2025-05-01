using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheBridge.Data.Entities;
using TheBridge.Dtos;
using TheBridge.Repositories.Repos.Contracts;
using TheBridge.Shared;

namespace TheBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Country>>>> GetAll()
        {
            try
            {
                var countries = await _countryService.GetAllCountriesAsync();
                return Ok(Response<IEnumerable<Country>>.SuccessResponse(countries));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<IEnumerable<Country>>.FailResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Country>>> Get(Guid id)
        {
            try
            {
                var country = await _countryService.GetCountryByIdAsync(id);
                if (country == null)
                    return NotFound(Response<Country>.FailResponse("Country not found"));

                return Ok(Response<Country>.SuccessResponse(country));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<Country>.FailResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create([FromBody] CountryDto country)
        {
            try
            {
                await _countryService.CreateCountryAsync(country);
                return Ok(Response<string>.SuccessResponse(null, "Created successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<string>.FailResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Update([FromBody] UpdateCountryDto country)
        {
            try
            {
                await _countryService.UpdateCountryAsync(country);
                return Ok(Response<string>.SuccessResponse(null, "Updated successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<string>.FailResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<string>>> Delete(Guid id)
        {
            try
            {
                await _countryService.DeleteCountryAsync(id);
                return Ok(Response<string>.SuccessResponse(null, "Deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<string>.FailResponse(ex.Message));
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<Response<IEnumerable<Country>>>> GetPaged(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var countries = await _countryService.GetCountriesPagedAsync(pageIndex, pageSize);
                return Ok(Response<IEnumerable<Country>>.SuccessResponse(countries));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<IEnumerable<Country>>.FailResponse(ex.Message));
            }
        }
    }

}
