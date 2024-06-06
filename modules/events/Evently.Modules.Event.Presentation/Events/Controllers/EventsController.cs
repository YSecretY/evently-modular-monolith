using Evently.Modules.Event.Application.Events.Cancel;
using Evently.Modules.Event.Application.Events.Create;
using Evently.Modules.Event.Application.Events.Get;
using Evently.Modules.Event.Application.Events.GetList;
using Evently.Modules.Event.Application.Events.Publish_;
using Evently.Modules.Event.Application.Events.Reschedule;
using Evently.Modules.Event.Application.Events.Search;
using Evently.Modules.Event.Presentation.Events.Requests.Cancel;
using Evently.Modules.Event.Presentation.Events.Requests.Create;
using Evently.Modules.Event.Presentation.Events.Requests.Get;
using Evently.Modules.Event.Presentation.Events.Requests.GetList;
using Evently.Modules.Event.Presentation.Events.Requests.Publish_;
using Evently.Modules.Event.Presentation.Events.Requests.Reschedule;
using Evently.Modules.Event.Presentation.Events.Requests.Search;
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
        var command = mapper.Map<CreateEventCommand>(request);

        var eventId = await mediator.Send(command, cancellationToken);

        return Ok(eventId);
    }

    [HttpGet("get")]
    public async Task<ActionResult<EventResponse>> GetEvent([FromQuery] GetEventRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetEventQuery>(request);

        var eventEntity = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<EventResponse>(eventEntity));
    }

    [HttpGet("get-list")]
    public async Task<ActionResult<GetEventsListResponse>> GetEventsList([FromQuery] GetEventsListRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetEventsListQuery>(request);

        var response = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<GetEventsListResponse>(response));
    }

    [HttpPut("publish")]
    public async Task<IActionResult> PublishEvent([FromQuery] PublishEventRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<PublishEventCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut("reschedule")]
    public async Task<IActionResult> RescheduleEvent([FromQuery] RescheduleEventRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<RescheduleEventCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut("cancel")]
    public async Task<IActionResult> CancelEvent([FromQuery] CancelEventRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CancelEventCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpGet("search")]
    public async Task<ActionResult<SearchEventsResponse>> SearchEvents([FromQuery] SearchEventsRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<SearchEventsQuery>(request);

        var response = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<SearchEventsResponse>(response));
    }
}