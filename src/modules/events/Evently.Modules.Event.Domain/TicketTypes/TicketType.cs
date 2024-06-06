using System.ComponentModel.DataAnnotations;
using Evently.Modules.Event.Domain.Abstractions;
using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Domain.TicketTypes.DomainEvents;

namespace Evently.Modules.Event.Domain.TicketTypes;

public sealed class TicketType : Entity
{
    private TicketType
    (
        Guid eventId,
        string name,
        decimal price,
        string currency,
        int quantity
    )
    {
        Id = Guid.NewGuid();
        EventId = eventId;
        Name = name;
        Price = price;
        Currency = currency;
        Quantity = quantity;
    }

    public Guid Id { get; private init; }

    public Guid EventId { get; private set; }

    public EventEntity Event { get; private set; } = null!;

    [MaxLength(256)] public string Name { get; private set; }

    public decimal Price { get; private set; }

    [MaxLength(10)] public string Currency { get; private set; }

    public int Quantity { get; private set; }

    public static TicketType Create(
        Guid eventId,
        string name,
        decimal price,
        string currency,
        int quantity
    )
    {
        if (price < 0)
            throw new ValidationException("Price cannot be less than 0.");

        if (quantity < 0)
            throw new ValidationException("Quantity cannot be less than 0.");

        var ticketType = new TicketType
        (
            eventId: eventId,
            name: name,
            price: price,
            currency: currency,
            quantity: quantity
        );

        ticketType.Raise(new TicketTypeCreatedDomainEvent(ticketType.Id));

        return ticketType;
    }

    public void UpdatePrice(decimal price)
    {
        if (price < 0)
            throw new ValidationException("Price cannot be less than 0.");

        if (Price == price)
            return;

        Price = price;

        Raise(new TicketTypePriceChangedDomainEvent(Id, Price));
    }
}