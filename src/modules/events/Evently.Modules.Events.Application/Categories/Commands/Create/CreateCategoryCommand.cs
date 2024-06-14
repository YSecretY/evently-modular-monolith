using MediatR;

namespace Evently.Modules.Events.Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand(string Name) : IRequest<Guid>;