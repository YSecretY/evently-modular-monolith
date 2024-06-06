using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.TicketTypes.Commands.UpdatePrice;

public class UpdateTicketTypePriceCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<UpdateTicketTypePriceCommand>
{
    public async Task Handle(UpdateTicketTypePriceCommand request, CancellationToken cancellationToken)
    {
        var ticketType = await dbContext.TicketTypes
                             .FirstOrDefaultAsync(t => t.Id == request.TicketTypeId, cancellationToken)
                         ?? throw new KeyNotFoundException("Ticket type is not found.");

        ticketType.UpdatePrice(request.Price);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}