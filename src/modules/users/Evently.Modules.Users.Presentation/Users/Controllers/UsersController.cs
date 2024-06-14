using Evently.Modules.Users.Application.Users.Commands.Register;
using Evently.Modules.Users.Presentation.Users.Requests.Register;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evently.Modules.Users.Presentation.Users.Controllers;

[Route("api/users")]
public class UsersController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<RegisterUserCommand>(request);

        return await mediator.Send(command, cancellationToken);
    }
}