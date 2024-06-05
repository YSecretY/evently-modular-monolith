using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.TicketTypes;

public sealed class TicketTypeCreatedDomainEvent(Guid ticketTypeId) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}