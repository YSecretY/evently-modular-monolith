namespace Evently.Modules.Event.Presentation.Events.Requests.Search;

public sealed record SearchEventsRequest(
    Guid? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    int PageNumber,
    int PageSize
);