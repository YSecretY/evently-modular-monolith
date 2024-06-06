using FluentValidation;

namespace Evently.Modules.Event.Application.TicketTypes.Queries.GetList;

internal sealed class GetTicketTypesListQueryValidator : AbstractValidator<GetTicketTypesListQuery>
{
    public GetTicketTypesListQueryValidator()
    {
        RuleFor(q => q.PageNumber).GreaterThan(0);
        RuleFor(q => q.PageSize).GreaterThan(0);
    }
}