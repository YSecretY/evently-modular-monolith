using Evently.Modules.Events.Application.Categories;

namespace Evently.Modules.Events.Presentation.Categories.Requests.GetList;

public record GetCategoriesListResponse(
    List<CategoryDto> Categories,
    int PageNumber,
    int PageSize,
    int MaxPages
);