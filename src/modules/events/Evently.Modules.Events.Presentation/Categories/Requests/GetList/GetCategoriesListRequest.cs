namespace Evently.Modules.Events.Presentation.Categories.Requests.GetList;

public sealed record GetCategoriesListRequest(
    int PageSize,
    int PageNumber
);