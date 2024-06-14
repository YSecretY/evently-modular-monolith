using Evently.Modules.Events.Domain.Categories;
using Evently.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Domain.Events;

public interface IEventsDbContext
{
    public DbSet<EventEntity> Events { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<TicketType> TicketTypes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}