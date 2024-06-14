using FluentValidation;

namespace Evently.Modules.Events.Application.Categories.Commands.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
