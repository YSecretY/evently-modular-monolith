using Evently.Modules.Event.Domain.Categories;
using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Infrastructure.Database;

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