using Evently.Modules.Event.Domain.Categories;

namespace Evently.Modules.Event.Application.Categories.Queries.GetList;

public sealed record GetCategoriesListQueryResponse(
    List<Category> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);