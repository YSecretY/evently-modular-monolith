namespace Evently.Modules.Event.Presentation.Categories.Requests.GetList;

public sealed record GetCategoriesListRequest(
    int PageSize,
    int PageNumber
);