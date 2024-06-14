using FluentValidation;

namespace Evently.Modules.Events.Application.Events.Queries.Get;

public class GetEventQueryValidator : AbstractValidator<GetEventQuery>
{
    public GetEventQueryValidator()
    {
        RuleFor(q => q.EventId).NotEmpty();
    }
}