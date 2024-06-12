using FluentValidation;

namespace Evently.Modules.Event.Application.Events.Queries.GetList;

internal sealed class GetEventsListQueryValidator : AbstractValidator<GetEventsListQuery>
{
    public GetEventsListQueryValidator()
    {
        RuleFor(q => q.PageNumber).GreaterThan(0);
        RuleFor(q => q.PageSize).GreaterThan(0);
    }
}