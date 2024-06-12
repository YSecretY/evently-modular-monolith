using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.TicketTypes.DomainEvents;

public sealed class TicketTypePriceChangedDomainEvent(Guid ticketId, decimal price) : DomainEvent
{
    public Guid TicketId { get; set; } = ticketId;
    public decimal Price { get; set; } = price;
}