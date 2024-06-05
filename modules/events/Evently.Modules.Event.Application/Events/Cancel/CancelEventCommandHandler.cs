using Evently.Modules.Event.Application.Abstraction;
using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Cancel;

public class CancelEventCommandHandler(
    IEventsDbContext dbContext,
    IDateTimeProvider dateTimeProvider
) : IRequestHandler<CancelEventCommand>
{
    public async Task Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events
                              .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken)
                          ?? throw new KeyNotFoundException("Event was not found.");

        eventEntity.Cancel(dateTimeProvider.CurrentTime);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}