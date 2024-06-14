namespace Evently.Modules.Users.Presentation.Users.Requests.Register;

public sealed record RegisterUserRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName
);