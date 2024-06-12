using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories
                           .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
                       ?? throw new KeyNotFoundException("Category is not found.");

        category.ChangeName(request.Name);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}