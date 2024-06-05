using Evently.Modules.Event.Application.Events.Create;
using Evently.Modules.Event.Application.Events.Get;
using Evently.Modules.Event.Presentation.Events.Create;
using Evently.Modules.Event.Presentation.Events.Get;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evently.Modules.Event.Presentation.Events.Controllers;

[Route("api/events")]
public class EventsController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult<CreateEventResponse>> CreateEvent([FromBody] CreateEventRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateEventCommand
        (
            Title: request.Title,
            Description: request.Description,
            Location: request.Location,
            CategoryId: request.CategoryId,
            StartsAtUtc: request.StartsAtUtc,
            EndsAtUtc: request.EndsAtUtc
        );

        var eventId = await mediator.Send(command, cancellationToken);

        return Ok(eventId);
    }

    [HttpGet("get")]
    public async Task<ActionResult<EventResponse>> GetEvent([FromQuery] GetEventRequest request, CancellationToken cancellationToken)
    {
        var query = new GetEventQuery
        (
            EventId: request.EventId
        );

        var eventEntity = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<EventResponse>(eventEntity));
    }
}