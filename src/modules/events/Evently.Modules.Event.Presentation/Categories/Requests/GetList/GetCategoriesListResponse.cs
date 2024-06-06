namespace Evently.Modules.Event.Presentation.Categories.Requests.GetList;

public record GetCategoriesListResponse(
    List<CategoryResponse> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);