using Evently.Modules.Event.Application.Categories;
using Evently.Modules.Event.Application.Categories.Commands.Archive;
using Evently.Modules.Event.Application.Categories.Commands.Create;
using Evently.Modules.Event.Application.Categories.Commands.Update;
using Evently.Modules.Event.Application.Categories.Queries.Get;
using Evently.Modules.Event.Application.Categories.Queries.GetList;
using Evently.Modules.Event.Domain.Categories;
using Evently.Modules.Event.Presentation.Categories.Requests.Archive;
using Evently.Modules.Event.Presentation.Categories.Requests.Create;
using Evently.Modules.Event.Presentation.Categories.Requests.Get;
using Evently.Modules.Event.Presentation.Categories.Requests.GetList;
using Evently.Modules.Event.Presentation.Categories.Requests.Update;
using Mapster;

namespace Evently.Modules.Event.Presentation.Categories.Mapping;

public class CategoriesMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.IsArchived, src => src.IsArchived);

        config.NewConfig<GetCategoryRequest, GetCategoryQuery>()
            .Map(dest => dest.CategoryId, src => src.CategoryId);

        config.NewConfig<CreateCategoryRequest, CreateCategoryCommand>()
            .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<ArchiveCategoryRequest, ArchiveCategoryCommand>()
            .Map(dest => dest.CategoryId, src => src.CategoryId);

        config.NewConfig<GetCategoriesListRequest, GetCategoriesListQuery>()
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber);

        config.NewConfig<GetCategoriesListQueryResponse, GetCategoriesListResponse>()
            .Map(dest => dest.Categories, src => src.Categories)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.MaxPages, src => src.MaxPages);

        config.NewConfig<UpdateCategoryRequest, UpdateCategoryCommand>()
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Name, src => src.Name);
    }
}