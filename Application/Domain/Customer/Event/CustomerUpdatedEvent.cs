using Application.Domain.shared.Event;

namespace Application.Domain.Customer.Event;

public class CustomerUpdatedEvent : DomainEvent
{
    public CustomerUpdatedEvent(string eventData)
    {
        EventData = eventData;
        DataTimeOccurred = DateTime.Now;
    }
}