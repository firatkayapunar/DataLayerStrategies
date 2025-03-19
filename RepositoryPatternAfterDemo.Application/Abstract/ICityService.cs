using RepositoryPatternAfterDemo.Entities;

namespace RepositoryPatternAfterDemo.Application.Abstract
{
    public interface ICityService
    {
        Task CreateCityAsync(string name);
        Task<List<City>> GetAllCitiesAsync();
    }
}
