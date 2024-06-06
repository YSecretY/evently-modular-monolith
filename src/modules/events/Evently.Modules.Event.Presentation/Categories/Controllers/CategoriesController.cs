using Evently.Modules.Event.Application.Categories.Commands.Archive;
using Evently.Modules.Event.Application.Categories.Commands.Create;
using Evently.Modules.Event.Application.Categories.Commands.Update;
using Evently.Modules.Event.Application.Categories.Queries.Get;
using Evently.Modules.Event.Application.Categories.Queries.GetList;
using Evently.Modules.Event.Presentation.Categories.Requests.Archive;
using Evently.Modules.Event.Presentation.Categories.Requests.Create;
using Evently.Modules.Event.Presentation.Categories.Requests.Get;
using Evently.Modules.Event.Presentation.Categories.Requests.GetList;
using Evently.Modules.Event.Presentation.Categories.Requests.Update;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evently.Modules.Event.Presentation.Categories.Controllers;

[Route("api/categories")]
public class CategoriesController(
    ISender mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateCategoryCommand>(request);

        var categoryId = await mediator.Send(command, cancellationToken);

        return Ok(categoryId);
    }

    [HttpGet("get")]
    public async Task<ActionResult<CategoryResponse>> Get([FromQuery] GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetCategoryQuery>(request);

        var category = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<CategoryResponse>(category));
    }

    [HttpGet("get-list")]
    public async Task<ActionResult<GetCategoriesListResponse>> GetList([FromQuery] GetCategoriesListRequest request, CancellationToken cancellationToken)
    {
        var query = mapper.Map<GetCategoriesListQuery>(request);

        var response = await mediator.Send(query, cancellationToken);

        return Ok(mapper.Map<GetCategoriesListResponse>(response));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<UpdateCategoryCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut("archive")]
    public async Task<IActionResult> Archive([FromQuery] ArchiveCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<ArchiveCategoryCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}