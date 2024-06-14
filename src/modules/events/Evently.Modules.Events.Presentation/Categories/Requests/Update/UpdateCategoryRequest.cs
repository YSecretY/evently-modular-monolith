namespace Evently.Modules.Events.Presentation.Categories.Requests.Update;

public sealed record UpdateCategoryRequest(Guid CategoryId, string Name);