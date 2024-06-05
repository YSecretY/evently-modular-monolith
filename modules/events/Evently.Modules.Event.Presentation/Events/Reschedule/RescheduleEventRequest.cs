namespace Evently.Modules.Event.Presentation.Events.Reschedule;

public sealed record RescheduleEventRequest(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc);