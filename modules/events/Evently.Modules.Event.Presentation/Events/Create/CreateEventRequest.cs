namespace Evently.Modules.Event.Presentation.Events.Create;

public sealed record CreateEventRequest(
    string Title,
    string Description,
    string Location,
    Guid CategoryId,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
);