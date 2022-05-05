using Flow.ResourceManager.Application.Common.Interfaces;
using Flow.ResourceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.ResourceManager.Application.UnitTests.Persistence;

public class FakeApplicationDbContext : DbContext, IApplicationDbContext
{
    public FakeApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }

    public DbSet<Trader> Traders { get; set; }

    public DbSet<Company> Companies { get; set; }
}