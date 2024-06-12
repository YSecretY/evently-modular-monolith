using MediatR;

namespace Evently.Modules.Event.Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand(string Name) : IRequest<Guid>;