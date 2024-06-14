using System.ComponentModel.DataAnnotations;
using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Categories;

public sealed class Category : Entity
{
    private Category()
    {
    }

    public Guid Id { get; private init; }

    [MaxLength(256)] public string Name { get; private set; } = string.Empty;

    public bool IsArchived { get; private set; }

    public static Category Create(string name)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            IsArchived = false
        };

        category.Raise(new CategoryCreatedDomainEvent(category.Id));

        return category;
    }

    public void Archive()
    {
        IsArchived = true;

        Raise(new CategoryArchivedDomainEvent(Id));
    }

    public void ChangeName(string name)
    {
        if (Name == name)
            return;

        Name = name;

        Raise(new CategoryNameChangedDomainEvent(Id, Name));
    }
}