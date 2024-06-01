using Application.Services.Repository;
using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateChanges()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (entity is Entity<Guid> _entity)
                        _entity.Id = Guid.NewGuid();
                    entity.CreationDate = DateTime.UtcNow;
                    entity.ModificationDate = null;
                    break;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entity is Entity<Guid> _entity)
                        Entry(_entity).Property(x => x.Id).IsModified = false;
                    Entry(entity).Property(x => x.CreationDate).IsModified = false;
                    entity.ModificationDate = DateTime.UtcNow;
                    break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Url> Urls { get; set; }
    }
}
