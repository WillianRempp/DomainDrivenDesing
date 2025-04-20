namespace Application.Domain.shared.Event;

public abstract class DomainEvent
{
    public DateTime DataTimeOccurred { get; set; }
    public string EventData { get; set; }
}