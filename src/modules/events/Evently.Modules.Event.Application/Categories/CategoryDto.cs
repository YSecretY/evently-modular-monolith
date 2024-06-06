namespace Evently.Modules.Event.Application.Categories;

public sealed record CategoryDto(
    Guid Id,
    string Name,
    bool IsArchived
);