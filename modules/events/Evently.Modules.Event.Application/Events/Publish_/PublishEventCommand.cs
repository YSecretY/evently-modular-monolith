using MediatR;

namespace Evently.Modules.Event.Application.Events.Publish_;

public sealed record PublishEventCommand(Guid EventId) : IRequest;