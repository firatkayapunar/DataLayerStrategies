using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Application.Abstract;

namespace RepositoryPatternDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCity([FromBody] string cityName)
        {
            await _cityService.CreateCityAsync(cityName);
            return Ok("City created successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }
    }
}
