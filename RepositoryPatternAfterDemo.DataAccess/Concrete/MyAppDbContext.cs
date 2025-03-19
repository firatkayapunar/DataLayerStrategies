using Microsoft.EntityFrameworkCore;
using RepositoryPatternAfterDemo.DataAccess.Abstract;
using RepositoryPatternAfterDemo.Entities;

namespace RepositoryPatternAfterDemo.DataAccess.Concrete
{
    public class MyAppDbContext : DbContext, IMyAppDbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities => Set<City>();
    }
}
