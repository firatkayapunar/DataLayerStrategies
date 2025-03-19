using Microsoft.EntityFrameworkCore;
using RepositoryPatternAfterDemo.Application.Abstract;
using RepositoryPatternAfterDemo.DataAccess.Abstract;
using RepositoryPatternAfterDemo.Entities;

namespace RepositoryPatternAfterDemo.Application.Concrete
{
    public class CityService : ICityService
    {
        private readonly IMyAppDbContext _context;

        public CityService(IMyAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCityAsync(string name)
        {
            var city = new City { Name = name };
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                                 .OrderBy(c => c.Name)
                                 .ToListAsync();
        }
    }
}
