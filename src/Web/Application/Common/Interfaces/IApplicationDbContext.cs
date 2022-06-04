using Flow.WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.WebAPI.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    
    DbSet<Item> Items { get; }
    
    DbSet<Company> Companies { get; }
    
    DbSet<Trader> Traders{ get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
