using System.ComponentModel.DataAnnotations;
using Evently.Modules.Events.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Categories.Queries.GetList;

public class GetCategoriesListQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetCategoriesListQuery, GetCategoriesListQueryResponse>
{
    public async Task<GetCategoriesListQueryResponse> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var maxPages = (int)Math.Ceiling((double)await dbContext.Categories.CountAsync(cancellationToken) / request.PageSize);

        if (maxPages is 0)
            throw new KeyNotFoundException("No categories.");

        if (request.PageNumber > maxPages)
            throw new ValidationException("Page number cannot be greater than max pages.");

        var categories = await dbContext.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetCategoriesListQueryResponse(
            Categories: mapper.Map<List<CategoryDto>>(categories),
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            MaxPages: maxPages
        );
    }
}