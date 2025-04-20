namespace Application.Domain.shared;

public interface IEventDispatcher
{
    Task Notify(Event @event);
    Task Register(string eventName, IEventHandler handler);
    Task Unregister(string eventName, IEventHandler handler);
    Task UnregisterAll();
}