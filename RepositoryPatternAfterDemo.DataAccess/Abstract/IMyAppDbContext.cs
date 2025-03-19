using Microsoft.EntityFrameworkCore;
using RepositoryPatternAfterDemo.Entities;

namespace RepositoryPatternAfterDemo.DataAccess.Abstract
{
    public interface IMyAppDbContext
    {
        DbSet<City> Cities { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
