using MediatR;

namespace Evently.Modules.Event.Application.Categories.Queries.Get;

public sealed record GetCategoryQuery(Guid CategoryId) : IRequest<CategoryDto>;