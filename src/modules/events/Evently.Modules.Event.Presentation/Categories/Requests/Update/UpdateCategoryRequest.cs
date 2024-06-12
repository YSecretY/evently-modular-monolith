namespace Evently.Modules.Event.Presentation.Categories.Requests.Update;

public sealed record UpdateCategoryRequest(Guid CategoryId, string Name);