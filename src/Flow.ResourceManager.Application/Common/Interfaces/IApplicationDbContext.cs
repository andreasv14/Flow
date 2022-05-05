using Flow.ResourceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Item> Items { get; set; }

    public DbSet<Trader> Traders { get; set; }

    public DbSet<Company> Companies { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}