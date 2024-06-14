using System.ComponentModel.DataAnnotations;
using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Users.Domain.Users;

public sealed class User : Entity
{
    private User(string email, string firstName, string lastName, DateTime createdAtUtc)
    {
        Id = Guid.NewGuid();
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        CreatedAtUtc = createdAtUtc;
    }

    public Guid Id { get; private init; }

    [MaxLength(512)] public string Email { get; private set; }

    [MaxLength(256)] public string FirstName { get; private set; }

    [MaxLength(256)] public string LastName { get; private set; }

    public DateTime CreatedAtUtc { get; set; }

    public static User Create(string email, string firstName, string lastName, DateTime createdAtUtc)
    {
        if (email.Length > 512)
            throw new ValidationException("Email is too long.");

        if (firstName.Length > 256)
            throw new ValidationException("First name is too long.");

        if (lastName.Length > 256)
            throw new ValidationException("Last name is too long.");

        if (string.IsNullOrEmpty(email))
            throw new ValidationException("Email cannot be empty.");

        if (string.IsNullOrEmpty(firstName))
            throw new ValidationException("First name cannot be empty.");

        if (string.IsNullOrEmpty(lastName))
            throw new ValidationException("Last name is cannot be empty.");

        var user = new User(
            email: email,
            firstName: firstName,
            lastName: lastName,
            createdAtUtc: createdAtUtc
        );

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        return user;
    }

    public void Update(string firstName, string lastName)
    {
        if (FirstName == firstName && LastName == lastName)
        {
            return;
        }

        if (string.IsNullOrEmpty(firstName))
            throw new ValidationException("First name cannot be empty.");

        if (string.IsNullOrEmpty(lastName))
            throw new ValidationException("Last name is cannot be empty.");

        if (firstName.Length > 256)
            throw new ValidationException("First name is too long.");

        if (lastName.Length > 256)
            throw new ValidationException("Last name is too long.");

        FirstName = firstName;
        LastName = lastName;

        Raise(new UserProfileUpdatedDomainEvent(Id, FirstName, LastName));
    }
}