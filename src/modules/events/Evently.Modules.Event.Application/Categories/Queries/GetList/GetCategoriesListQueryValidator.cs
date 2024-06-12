using FluentValidation;

namespace Evently.Modules.Event.Application.Categories.Queries.GetList;

internal sealed class GetCategoriesListQueryValidator : AbstractValidator<GetCategoriesListQuery>
{
    public GetCategoriesListQueryValidator()
    {
        RuleFor(q => q.PageNumber).GreaterThan(0);
        RuleFor(q => q.PageSize).GreaterThan(0);
    }
}