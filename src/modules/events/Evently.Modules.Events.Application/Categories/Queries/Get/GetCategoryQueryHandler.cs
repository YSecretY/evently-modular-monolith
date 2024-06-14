using Evently.Modules.Events.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Categories.Queries.Get;

public class GetCategoryQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories
                           .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
                       ?? throw new KeyNotFoundException("Category id not found.");

        return mapper.Map<CategoryDto>(category);
    }
}