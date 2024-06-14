using Evently.Modules.Events.Domain.Categories;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IEventsDbContext
{
    public DbSet<EventEntity> Events { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<TicketType> TicketTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}