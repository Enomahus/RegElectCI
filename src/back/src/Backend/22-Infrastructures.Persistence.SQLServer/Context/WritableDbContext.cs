using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructures.Persistence.SQLServer.Context
{
    public class WritableDbContext : ApplicationDbContext
    {
        private readonly TimeProvider _timeProvider;

        public WritableDbContext() { }

        public WritableDbContext(
            DbContextOptions<ApplicationDbContext> options,
            TimeProvider timeProvider
        )
            : base(options)
        {
            _timeProvider = timeProvider;
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<ITimestampedEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = _timeProvider.GetUtcNow();
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = _timeProvider.GetUtcNow();
                }

                UpdateTimestampByNavigationProperties(entry);
            }
        }

        private void UpdateTimestampByNavigationProperties(EntityEntry<ITimestampedEntity> entry)
        {
            bool isModified = false;
            foreach (var currentItem in entry.Navigations.Select(p => p.CurrentValue))
            {
                if (currentItem is IEnumerable<object> collection)
                {
                    var itemsModified = collection.Where(IsItemModified).ToList();
                    if (itemsModified.Count == 0)
                    {
                        entry.Entity.ModifiedAt = _timeProvider.GetUtcNow();
                        isModified = true;
                    }
                }
                else if (currentItem != null && IsItemModified(currentItem))
                {
                    entry.Entity.ModifiedAt = _timeProvider.GetUtcNow();
                    isModified = true;
                }

                if (isModified)
                    break;
            }
        }

        private bool IsItemModified(object item)
        {
            return ChangeTracker
                .Entries()
                .Any(e => e.Entity == item && e.State == EntityState.Modified);
        }
    }
}
