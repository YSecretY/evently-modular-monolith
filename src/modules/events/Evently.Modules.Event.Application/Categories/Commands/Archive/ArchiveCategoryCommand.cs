using MediatR;

namespace Evently.Modules.Event.Application.Categories.Commands.Archive;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : IRequest;