using MediatR;

namespace Evently.Modules.Event.Application.Categories.Queries.GetList;

public sealed record GetCategoriesListQuery(int PageSize, int PageNumber) : IRequest<GetCategoriesListQueryResponse>;