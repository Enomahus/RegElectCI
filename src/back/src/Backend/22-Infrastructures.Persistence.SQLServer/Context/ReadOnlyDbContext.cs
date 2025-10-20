using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Persistence.SQLServer.Context
{
    public class ReadOnlyDbContext : ApplicationDbContext
    {
        public ReadOnlyDbContext() { }

        public ReadOnlyDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
