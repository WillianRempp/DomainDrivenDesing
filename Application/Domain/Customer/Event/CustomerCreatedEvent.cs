using Application.Domain.shared.Event;

namespace Application.Domain.Customer.Event;

public class CustomerCreatedEvent : DomainEvent
{
    public CustomerCreatedEvent(string eventData)
    {
        EventData = eventData;
        DataTimeOccurred = DateTime.Now;
    }
}