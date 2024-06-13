using System.ComponentModel.DataAnnotations;
using Evently.Modules.Event.Domain.Events.DomainEvents;
using Evently.Modules.Event.Domain.TicketTypes;
using Evently.Shared.Domain.Abstractions;

namespace Evently.Modules.Event.Domain.Events;

public sealed class EventEntity : Entity
{
    private EventEntity
    (
        string title,
        string description,
        string location,
        Guid categoryId,
        DateTime startsAtUtc,
        DateTime? endsAtUtc
    )
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Location = location;
        CategoryId = categoryId;
        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;
        Status = EventStatus.Draft;
    }

    public Guid Id { get; private init; }

    public Guid CategoryId { get; private init; }

    [MaxLength(256)] public string Title { get; init; }

    [MaxLength(2048)] public string Description { get; init; }

    [MaxLength(1024)] public string Location { get; init; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public List<TicketType> TicketTypes { get; init; } = null!;

    public static EventEntity Create(
        string title,
        string description,
        string location,
        Guid categoryId,
        DateTime startsAtUtc,
        DateTime? endsAtUtc
    )
    {
        if (endsAtUtc < startsAtUtc)
            throw new ValidationException("End time cannot be earlier than the start one.");

        var eventEntity = new EventEntity
        (
            title: title,
            description: description,
            location: location,
            categoryId: categoryId,
            startsAtUtc: startsAtUtc,
            endsAtUtc: endsAtUtc
        );

        eventEntity.Raise(new EventCreatedDomainEvent(eventEntity.Id));

        return eventEntity;
    }

    public void Publish()
    {
        if (Status is not EventStatus.Draft)
            throw new ValidationException("Event is not draft.");

        Status = EventStatus.Published;

        Raise(new EventPublishedDomainEvent(Id));
    }

    public void Reschedule(DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        if (startsAtUtc == StartsAtUtc && EndsAtUtc == endsAtUtc)
            return;

        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;

        Raise(new EventRescheduledDomainEvent(eventId: Id, startsAtUtc: StartsAtUtc, endsAtUtc: EndsAtUtc));
    }

    public void Cancel(DateTime utcNow)
    {
        if (Status is EventStatus.Canceled)
            throw new ValidationException("Event is already canceled.");

        if (StartsAtUtc < utcNow)
            throw new ValidationException("Event is already started.");

        Status = EventStatus.Canceled;

        Raise(new EventCanceledDomainEvent(Id));
    }
}