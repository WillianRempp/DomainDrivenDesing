namespace Application.Domain.shared.Event;

public interface IEventDispatcher
{
    Task Notify(DomainEvent domainEvent);
    Task Register(string eventName, IEventHandler handler);
    Task Unregister(string eventName, IEventHandler handler);
    Task UnregisterAll();
}