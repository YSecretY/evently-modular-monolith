namespace Evently.Modules.Events.Application.Categories;

public sealed record CategoryDto(
    Guid Id,
    string Name,
    bool IsArchived
);