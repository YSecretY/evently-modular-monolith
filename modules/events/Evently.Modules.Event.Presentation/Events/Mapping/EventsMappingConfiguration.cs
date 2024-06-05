using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Domain.TicketTypes;
using Mapster;

namespace Evently.Modules.Event.Presentation.Events.Mapping;

public class EventsMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TicketType, TicketTypeResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.Currency, src => src.Currency);

        config.NewConfig<EventEntity, EventResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.StartsAtUtc, src => src.StartsAtUtc)
            .Map(dest => dest.EndsAtUtc, src => src.EndsAtUtc)
            .Map(dest => dest.TicketTypes, src => src.TicketTypes);
    }
}