using Evently.Modules.Events.Application.TicketTypes;
using Evently.Modules.Events.Application.TicketTypes.Commands.Create;
using Evently.Modules.Events.Application.TicketTypes.Commands.UpdatePrice;
using Evently.Modules.Events.Application.TicketTypes.Queries.Get;
using Evently.Modules.Events.Application.TicketTypes.Queries.GetList;
using Evently.Modules.Events.Domain.TicketTypes;
using Evently.Modules.Events.Presentation.TicketTypes.Requests.Create;
using Evently.Modules.Events.Presentation.TicketTypes.Requests.Get;
using Evently.Modules.Events.Presentation.TicketTypes.Requests.GetList;
using Evently.Modules.Events.Presentation.TicketTypes.Requests.UpdatePrice;
using Mapster;

namespace Evently.Modules.Events.Presentation.TicketTypes.Mapping;

public class TicketTypesMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TicketType, TicketTypeDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.EventId, src => src.Event)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Quantity, src => src.Quantity);

        config.NewConfig<CreateTicketTypeRequest, CreateTicketTypeCommand>()
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);

        config.NewConfig<GetTicketTypeRequest, GetTicketTypeQuery>()
            .Map(dest => dest.TicketTypeId, src => src.TicketTypeId);

        config.NewConfig<GetTicketTypesListRequest, GetTicketTypesListQuery>()
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber);

        config.NewConfig<GetTicketTypesListQueryResponse, GetTicketTypesListResponse>()
            .Map(dest => dest.TicketTypes, src => src.TicketTypes)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.MaxPages, src => src.MaxPages);

        config.NewConfig<UpdateTicketTypePriceRequest, UpdateTicketTypePriceCommand>()
            .Map(dest => dest.TicketTypeId, src => src.TicketTypeId)
            .Map(dest => dest.Price, src => src.Price);
    }
}