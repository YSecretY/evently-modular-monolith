using FluentValidation;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.Get;

public class GetTicketTypeQueryValidator : AbstractValidator<GetTicketTypeQuery>
{
    public GetTicketTypeQueryValidator()
    {
        RuleFor(q => q.TicketTypeId).NotEmpty();
    }
}