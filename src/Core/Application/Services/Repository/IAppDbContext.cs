using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Repository
{
    public interface IAppDbContext
    {
        public DbSet<Url> Urls { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
