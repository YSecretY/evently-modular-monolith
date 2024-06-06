using Evently.Modules.Event.Application.Categories.Commands.Archive;
using Evently.Modules.Event.Application.Categories.Commands.Create;
using Evently.Modules.Event.Presentation.Categories.Requests.Archive;
using Evently.Modules.Event.Presentation.Categories.Requests.Create;
using Mapster;

namespace Evently.Modules.Event.Presentation.Categories.Mapping;

public class CategoriesMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>()
            .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<ArchiveCategoryRequest, ArchiveCategoryCommand>()
            .Map(dest => dest.CategoryId, src => src.CategoryId);
    }
}