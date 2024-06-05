using Evently.Modules.Event.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Categories;

public sealed class CategoryCreatedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; set; } = categoryId;
}