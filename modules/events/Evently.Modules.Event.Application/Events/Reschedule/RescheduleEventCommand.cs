using MediatR;

namespace Evently.Modules.Event.Application.Events.Reschedule;

public sealed record RescheduleEventCommand(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc) : IRequest;