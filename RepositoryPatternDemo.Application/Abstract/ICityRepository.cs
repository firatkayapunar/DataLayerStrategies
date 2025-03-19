using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.Application.Abstract
{
    public interface ICityService
    {
        Task CreateCityAsync(string cityName);
        Task<List<City>> GetAllCitiesAsync();
    }
}
