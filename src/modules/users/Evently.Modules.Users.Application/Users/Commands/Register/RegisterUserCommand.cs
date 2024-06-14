using MediatR;

namespace Evently.Modules.Users.Application.Users.Commands.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<Guid>;