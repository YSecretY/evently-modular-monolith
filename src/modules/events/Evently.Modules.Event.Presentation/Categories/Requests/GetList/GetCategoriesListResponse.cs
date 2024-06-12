using Evently.Modules.Event.Application.Categories;

namespace Evently.Modules.Event.Presentation.Categories.Requests.GetList;

public record GetCategoriesListResponse(
    List<CategoryDto> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);