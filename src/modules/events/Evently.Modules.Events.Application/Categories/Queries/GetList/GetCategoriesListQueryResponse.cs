namespace Evently.Modules.Events.Application.Categories.Queries.GetList;

public sealed record GetCategoriesListQueryResponse(
    List<CategoryDto> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);