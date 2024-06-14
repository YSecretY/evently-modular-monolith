using MediatR;

namespace Evently.Modules.Events.Application.Categories.Queries.GetList;

public sealed record GetCategoriesListQuery(int PageSize, int PageNumber) : IRequest<GetCategoriesListQueryResponse>;