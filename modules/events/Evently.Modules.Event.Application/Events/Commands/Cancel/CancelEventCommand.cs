using MediatR;

namespace Evently.Modules.Event.Application.Events.Commands.Cancel;

public sealed record CancelEventCommand(Guid EventId) : IRequest;