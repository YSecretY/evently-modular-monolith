using FluentValidation;

namespace Evently.Modules.Event.Application.Categories.Commands.Archive;

public class ArchiveCategoryCommandValidator : AbstractValidator<ArchiveCategoryCommand>
{
    public ArchiveCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}