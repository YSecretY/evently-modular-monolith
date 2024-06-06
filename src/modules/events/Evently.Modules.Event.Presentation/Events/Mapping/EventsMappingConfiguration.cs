using Evently.Modules.Event.Application.Events;
using Evently.Modules.Event.Application.Events.Commands.Cancel;
using Evently.Modules.Event.Application.Events.Commands.Create;
using Evently.Modules.Event.Application.Events.Commands.Publish_;
using Evently.Modules.Event.Application.Events.Commands.Reschedule;
using Evently.Modules.Event.Application.Events.Queries.Get;
using Evently.Modules.Event.Application.Events.Queries.GetList;
using Evently.Modules.Event.Application.Events.Queries.Search;
using Evently.Modules.Event.Domain.Events;
using Evently.Modules.Event.Presentation.Events.Requests.Cancel;
using Evently.Modules.Event.Presentation.Events.Requests.Create;
using Evently.Modules.Event.Presentation.Events.Requests.Get;
using Evently.Modules.Event.Presentation.Events.Requests.GetList;
using Evently.Modules.Event.Presentation.Events.Requests.Publish_;
using Evently.Modules.Event.Presentation.Events.Requests.Reschedule;
using Evently.Modules.Event.Presentation.Events.Requests.Search;
using Mapster;
using SearchEventsResponse = Evently.Modules.Event.Presentation.Events.Requests.Search.SearchEventsResponse;

namespace Evently.Modules.Event.Presentation.Events.Mapping;

public class EventsMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EventEntity, EventDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.StartsAtUtc, src => src.StartsAtUtc)
            .Map(dest => dest.EndsAtUtc, src => src.EndsAtUtc)
            .Map(dest => dest.Status, src => src.Status.ToString());

        config.NewConfig<CreateEventRequest, CreateEventCommand>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.StartsAtUtc, src => src.StartsAtUtc)
            .Map(dest => dest.EndsAtUtc, src => src.EndsAtUtc);

        config.NewConfig<GetEventRequest, GetEventQuery>()
            .Map(dest => dest.EventId, src => src.EventId);

        config.NewConfig<GetEventsListRequest, GetEventsListQuery>()
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize);

        config.NewConfig<GetEventsListQueryResponse, GetEventsListResponse>()
            .Map(dest => dest.Events, src => src.Events)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.MaxPages, src => src.MaxPages);

        config.NewConfig<PublishEventRequest, PublishEventCommand>()
            .Map(dest => dest.EventId, src => src.EventId);

        config.NewConfig<RescheduleEventRequest, RescheduleEventCommand>()
            .Map(dest => dest.EventId, src => src.EventId)
            .Map(dest => dest.StartsAtUtc, src => src.StartsAtUtc)
            .Map(dest => dest.EndsAtUtc, src => src.EndsAtUtc);

        config.NewConfig<CancelEventRequest, CancelEventCommand>()
            .Map(dest => dest.EventId, src => src.EventId);

        config.NewConfig<SearchEventsRequest, SearchEventsQuery>()
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.StartDate, src => src.StartDate)
            .Map(dest => dest.EndDate, src => src.EndDate);

        config.NewConfig<SearchEventsResponse, SearchEventsQueryResponse>()
            .Map(dest => dest.Events, src => src.Events)
            .Map(dest => dest.PageNumber, src => src.PageNumber)
            .Map(dest => dest.PageSize, src => src.PageSize)
            .Map(dest => dest.TotalCount, src => src.TotalCount);
    }
}