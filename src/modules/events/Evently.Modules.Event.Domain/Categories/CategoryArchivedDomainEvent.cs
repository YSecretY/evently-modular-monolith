using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Categories;

public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
