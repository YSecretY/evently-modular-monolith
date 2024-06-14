using MediatR;

namespace Evently.Modules.Events.Application.Categories.Queries.Get;

public sealed record GetCategoryQuery(Guid CategoryId) : IRequest<CategoryDto>;