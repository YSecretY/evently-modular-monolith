namespace Evently.Modules.Events.Presentation.Events.Requests.Search;

public sealed record SearchEventsRequest(
    Guid? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    int PageNumber,
    int PageSize
);