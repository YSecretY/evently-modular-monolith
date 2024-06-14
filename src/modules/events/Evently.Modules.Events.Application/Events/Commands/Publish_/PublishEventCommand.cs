using MediatR;

namespace Evently.Modules.Events.Application.Events.Commands.Publish_;

public sealed record PublishEventCommand(Guid EventId) : IRequest;