using MediatR;

namespace Evently.Modules.Events.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : IRequest;