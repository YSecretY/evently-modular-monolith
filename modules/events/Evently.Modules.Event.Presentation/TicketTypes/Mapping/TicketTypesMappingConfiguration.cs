using Evently.Modules.Event.Application.TicketTypes.Commands.CreateTicketType;
using Evently.Modules.Event.Presentation.TicketTypes.Requests;
using Mapster;

namespace Evently.Modules.Event.Presentation.TicketTypes.Mapping;

public class TicketTypesMappingConfiguration : IRegister 
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTicketTypeRequest, CreateTicketTypeCommand>()
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Currency, src => src.Currency)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);
    }
}