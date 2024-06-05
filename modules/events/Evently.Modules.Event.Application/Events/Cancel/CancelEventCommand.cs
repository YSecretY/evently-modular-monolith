using MediatR;

namespace Evently.Modules.Event.Application.Events.Cancel;

public sealed record CancelEventCommand(Guid EventId) : IRequest;