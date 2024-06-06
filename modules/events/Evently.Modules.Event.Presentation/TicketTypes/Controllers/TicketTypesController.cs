using Evently.Modules.Event.Application.TicketTypes.Commands.CreateTicketType;
using Evently.Modules.Event.Presentation.TicketTypes.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evently.Modules.Event.Presentation.TicketTypes.Controllers;

[Route("api/ticket-types")]
public class TicketTypesController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketTypeRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateTicketTypeCommand>(request);

        var ticketTypeId = await mediator.Send(command, cancellationToken);

        return Ok(ticketTypeId);
    }
}