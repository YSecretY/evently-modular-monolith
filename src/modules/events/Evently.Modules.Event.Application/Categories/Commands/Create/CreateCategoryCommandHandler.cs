using Evently.Modules.Event.Domain.Categories;
using Evently.Modules.Event.Domain.Events;
using MediatR;

namespace Evently.Modules.Event.Application.Categories.Commands.Create;

public class CreateCategoryCommandHandler(
    IEventsDbContext dbContext
) : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        await dbContext.Categories.AddAsync(category, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}