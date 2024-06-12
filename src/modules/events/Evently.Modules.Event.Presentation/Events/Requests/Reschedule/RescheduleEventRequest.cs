namespace Evently.Modules.Event.Presentation.Events.Requests.Reschedule;

public sealed record RescheduleEventRequest(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc);