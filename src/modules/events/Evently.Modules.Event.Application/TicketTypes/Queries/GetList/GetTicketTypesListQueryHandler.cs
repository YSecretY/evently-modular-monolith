using System.ComponentModel.DataAnnotations;
using Evently.Modules.Event.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.GetList;

public class GetTicketTypesListQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetTicketTypesListQuery, GetTicketTypesListQueryResponse>
{
    public async Task<GetTicketTypesListQueryResponse> Handle(GetTicketTypesListQuery request, CancellationToken cancellationToken)
    {
        var maxPages = (int)Math.Ceiling((double)await dbContext.TicketTypes.CountAsync(cancellationToken) / request.PageSize);

        if (maxPages is 0)
            throw new KeyNotFoundException("No ticket types.");

        if (request.PageNumber > maxPages)
            throw new ValidationException("Page number cannot be greater than max pages.");

        var ticketTypes = await dbContext.TicketTypes
            .AsNoTracking()
            .OrderBy(t => t.Price)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new GetTicketTypesListQueryResponse(
            TicketTypes: mapper.Map<List<TicketTypeDto>>(ticketTypes),
            PageNumber: request.PageNumber,
            PageSize: request.PageSize,
            MaxPages: maxPages
        );
    }
}