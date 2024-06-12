using MediatR;

namespace Evently.Modules.Event.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : IRequest;