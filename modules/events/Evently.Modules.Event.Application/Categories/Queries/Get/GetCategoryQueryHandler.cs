using Evently.Modules.Event.Domain.Categories;
using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Categories.Queries.Get;

public class GetCategoryQueryHandler(
    IEventsDbContext dbContext
) : IRequestHandler<GetCategoryQuery, Category>
{
    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken) =>
        await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
        ?? throw new KeyNotFoundException("Category id not found.");
}