using RepositoryPatternDemo.DataAccess.Abstract;
using RepositoryPatternDemo.DataAccess.Concrete;
using RepositoryPatternDemo.DataAccess.Context;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.DataAccess
{
    public class EfCityRepository : BaseRepository<City>, ICityRepository
    {
        public EfCityRepository(MyAppDbContext context)
            : base(context)
        { }
    }
}
