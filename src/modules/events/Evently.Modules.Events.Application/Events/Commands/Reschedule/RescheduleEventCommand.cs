using MediatR;

namespace Evently.Modules.Events.Application.Events.Commands.Reschedule;

public sealed record RescheduleEventCommand(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc) : IRequest;