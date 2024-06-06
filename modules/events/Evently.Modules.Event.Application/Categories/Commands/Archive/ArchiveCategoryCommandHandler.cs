using Evently.Modules.Event.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.Categories.Commands.Archive;

public class ArchiveCategoryCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<ArchiveCategoryCommand>
{
    public async Task Handle(ArchiveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories
                           .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
                       ?? throw new KeyNotFoundException("Category is not found.");

        category.Archive();

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}