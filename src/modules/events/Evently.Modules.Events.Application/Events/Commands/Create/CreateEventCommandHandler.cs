using Evently.Modules.Events.Domain.Events;
using MediatR;

namespace Evently.Modules.Events.Application.Events.Commands.Create;

public sealed class CreateEventCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = EventEntity.Create
        (
            title: request.Title,
            description: request.Description,
            location: request.Location,
            categoryId: request.CategoryId,
            startsAtUtc: request.StartsAtUtc,
            endsAtUtc: request.EndsAtUtc
        );

        await dbContext.Events.AddAsync(eventEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return eventEntity.Id;
    }
}