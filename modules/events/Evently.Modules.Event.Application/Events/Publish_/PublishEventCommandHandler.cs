using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Events.Publish_;

public class PublishEventCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<PublishEventCommand>
{
    public async Task Handle(PublishEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = await dbContext.Events
                              .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken)
                          ?? throw new KeyNotFoundException("Event is not found.");

        eventEntity.Publish();

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}