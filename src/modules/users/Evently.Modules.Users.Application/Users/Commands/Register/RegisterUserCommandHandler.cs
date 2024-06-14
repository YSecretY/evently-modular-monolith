using Evently.Modules.Users.Domain.Users;
using Evently.Shared.Application.Abstractions.Time;
using MediatR;

namespace Evently.Modules.Users.Application.Users.Commands.Register;

public sealed class RegisterUserCommandHandler(
    IUsersDbContext dbContext,
    IDateTimeProvider dateTimeProvider
) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            email: request.Email,
            firstName: request.FirstName,
            lastName: request.LastName,
            createdAtUtc: dateTimeProvider.CurrentTime
        );

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}