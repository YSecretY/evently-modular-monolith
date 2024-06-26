using MediatR;

namespace Evently.Modules.Event.Application.Events.Commands.Publish_;

public sealed record PublishEventCommand(Guid EventId) : IRequest;