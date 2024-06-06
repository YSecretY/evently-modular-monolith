using Evently.Modules.Event.Application.TicketTypes.Commands.Create;
using Evently.Modules.Event.Application.TicketTypes.Commands.UpdatePrice;
using Evently.Modules.Event.Application.TicketTypes.Queries.Get;
using Evently.Modules.Event.Application.TicketTypes.Queries.GetList;
using Evently.Modules.Event.Presentation.TicketTypes.Requests.Create;
using Evently.Modules.Event.Presentation.TicketTypes.Requests.Get;
using Evently.Modules.Event.Presentation.TicketTypes.Requests.GetList;
using Evently.Modules.Event.Presentation.TicketTypes.Requests.UpdatePrice;
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

    [HttpGet("get")]
    public async Task<ActionResult<TicketTypeResponse>> Get([FromQuery] GetTicketTypeRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetTicketTypeQuery>(request);

        var ticketType = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<TicketTypeResponse>(ticketType));
    }

    [HttpGet("get-list")]
    public async Task<ActionResult<GetTicketTypesListResponse>> GetList([FromQuery] GetTicketTypesListRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetTicketTypesListQuery>(request);

        var response = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<GetTicketTypesListResponse>(response));
    }

    [HttpPut("update-price")]
    public async Task<IActionResult> UpdatePrice([FromBody] UpdateTicketTypePriceRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<UpdateTicketTypePriceCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}