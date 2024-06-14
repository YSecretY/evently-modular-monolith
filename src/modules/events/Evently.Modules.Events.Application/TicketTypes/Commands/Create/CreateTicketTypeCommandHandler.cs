using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Domain.TicketTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.TicketTypes.Commands.Create;

public class CreateTicketTypeCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<CreateTicketTypeCommand, Guid>
{
    public async Task<Guid> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var eventExists = await dbContext.Events
            .CountAsync(e => e.Id == request.EventId, cancellationToken) > 0;
        if (!eventExists) throw new KeyNotFoundException("Event is not found.");

        var ticketType = TicketType.Create
        (
            eventId: request.EventId,
            name: request.Name,
            price: request.Price,
            currency: request.Currency,
            quantity: request.Quantity
        );

        await dbContext.TicketTypes.AddAsync(ticketType, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return ticketType.Id;
    }
}