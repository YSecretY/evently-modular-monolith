namespace Evently.Modules.Event.Application.Categories.Queries.GetList;

public sealed record GetCategoriesListQueryResponse(
    List<CategoryDto> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);