using Application.Domain.shared.Event;

namespace Application.Domain.Product.Event;

public class ProductCreatedEvent : DomainEvent
{
    public ProductCreatedEvent(string eventData)
    {
        EventData = eventData;
        DataTimeOccurred = DateTime.Now;
    }
}