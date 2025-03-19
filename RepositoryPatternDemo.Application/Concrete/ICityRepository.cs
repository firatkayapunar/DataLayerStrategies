using RepositoryPatternDemo.Application.Abstract;
using RepositoryPatternDemo.DataAccess.Abstract;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.Application.Concrete
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CreateCityAsync(string cityName)
        {
            var city = new City { Name = cityName };
            await _cityRepository.AddAsync(city);
            await _cityRepository.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}
