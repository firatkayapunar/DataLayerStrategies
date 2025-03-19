using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.DataAccess.Context
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        { }

        public DbSet<City> Cities { get; set; }
    }
}
