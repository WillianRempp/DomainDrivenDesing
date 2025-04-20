namespace Application.Domain.Product.Event;

public class ProductCreatedEvent : shared.Event
{
    public ProductCreatedEvent(string eventData)
    {
        EventData = eventData;
        DataTimeOccurred = DateTime.Now;
    }
}