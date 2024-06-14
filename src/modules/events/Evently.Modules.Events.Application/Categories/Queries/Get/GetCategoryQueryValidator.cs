using FluentValidation;

namespace Evently.Modules.Events.Application.Categories.Queries.Get;

internal sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(q => q.CategoryId).NotEmpty();
    }
}