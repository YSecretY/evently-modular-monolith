using Evently.Modules.Events.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Events.Commands.Reschedule;

public class RescheduleEventCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<RescheduleEventCommand>
{
    public async Task Handle(RescheduleEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events
                              .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken)
                          ?? throw new KeyNotFoundException("Event is not found.");

        eventEntity.Reschedule(
            startsAtUtc: request.StartsAtUtc,
            endsAtUtc: request.EndsAtUtc
        );

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}