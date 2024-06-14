using MediatR;

namespace Evently.Modules.Events.Application.Categories.Commands.Archive;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : IRequest;