using FluentValidation;

namespace Evently.Modules.Event.Application.Events.Queries.Search;

public class SearchEventsQueryValidator : AbstractValidator<SearchEventsQuery>
{
    public SearchEventsQueryValidator()
    {
        RuleFor(q => q.CategoryId).NotEmpty();
        RuleFor(q => q.PageSize).GreaterThan(0).NotEmpty();
        RuleFor(q => q.PageNumber).GreaterThan(0).NotEmpty();
        RuleFor(q => q.EndDate).Must((query, endDate) => endDate > query.StartDate).When(q => q.StartDate.HasValue && q.EndDate.HasValue);
    }
}