using Microsoft.AspNetCore.Mvc;
using RepositoryPatternAfterDemo.Application.Abstract;

namespace RepositoryPatternAfterDemo.API.Controllers
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
        public async Task<IActionResult> CreateCity([FromBody] string name)
        {
            await _cityService.CreateCityAsync(name);
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
