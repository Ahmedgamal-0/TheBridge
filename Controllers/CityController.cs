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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<City>>>> GetAll()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return Ok(Response<IEnumerable<City>>.SuccessResponse(cities));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<IEnumerable<CityDto>>.FailResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<City>>> Get(Guid id)
        {
            try
            {
                var city = await _cityService.GetCityByIdAsync(id);
                if (city == null)
                    return NotFound(Response<City>.FailResponse("City not found"));

                return Ok(Response<City>.SuccessResponse(city));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<City>.FailResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create([FromBody] CityDto city)
        {
            try
            {
                await _cityService.CreateCityAsync(city);
                return Ok(Response<string>.SuccessResponse(null, "City created successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<string>.FailResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Update([FromBody] UpdateCityDto city)
        {
            try
            {
                await _cityService.UpdateCityAsync(city);
                return Ok(Response<string>.SuccessResponse(city.Name, "City updated successfully"));
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
                await _cityService.DeleteCityAsync(id);
                return Ok(Response<string>.SuccessResponse(null, "City deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<string>.FailResponse(ex.Message));
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<Response<IEnumerable<CityDto>>>> GetPaged(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var cities = await _cityService.GetCitiesPagedAsync(pageIndex, pageSize);
                var data = _mapper.Map<IEnumerable<CityDto>>(cities);
                return Ok(Response<IEnumerable<CityDto>>.SuccessResponse(data));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<IEnumerable<CityDto>>.FailResponse(ex.Message));
            }
        }
    }

}
