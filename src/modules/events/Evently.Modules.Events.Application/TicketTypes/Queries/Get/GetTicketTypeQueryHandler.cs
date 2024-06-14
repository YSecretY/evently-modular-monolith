using Evently.Modules.Events.Domain.Events;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.TicketTypes.Queries.Get;

public class GetTicketTypeQueryHandler(
    IEventsDbContext dbContext,
    IMapper mapper
) : IRequestHandler<GetTicketTypeQuery, TicketTypeDto>
{
    public async Task<TicketTypeDto> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        var ticketType = await dbContext.TicketTypes
                             .AsNoTracking()
                             .FirstOrDefaultAsync(t => t.Id == request.TicketTypeId, cancellationToken)
                         ?? throw new KeyNotFoundException("Ticket type is not found.");

        return mapper.Map<TicketTypeDto>(ticketType);
    }
}