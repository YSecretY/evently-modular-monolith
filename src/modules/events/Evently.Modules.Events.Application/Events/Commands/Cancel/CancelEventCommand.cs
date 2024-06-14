using MediatR;

namespace Evently.Modules.Events.Application.Events.Commands.Cancel;

public sealed record CancelEventCommand(Guid EventId) : IRequest;