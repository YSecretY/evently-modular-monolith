using Evently.Modules.Event.Application.Categories.Commands.Archive;
using Evently.Modules.Event.Presentation.Categories.Requests;
using Mapster;

namespace Evently.Modules.Event.Presentation.Categories.Mapping;

public class CategoriesMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ArchiveCategoryRequest, ArchiveCategoryCommand>()
            .Map(dest => dest.CategoryId, src => src.CategoryId);
    }
}