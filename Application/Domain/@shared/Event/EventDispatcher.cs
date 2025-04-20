namespace Application.Domain.shared.Event;

public class EventDispatcher : IEventDispatcher
{
    private List<Dictionary<string, IEventHandler>> _handlers = [];

    public List<Dictionary<string, IEventHandler>> GetEventHandlers()
    {
        return _handlers;
    }

    public Task Notify(DomainEvent domainEvent)
    {
        foreach (var handler in
                 _handlers.Where(handler => handler.ContainsKey(domainEvent.GetType().Name)))
        {
            handler[domainEvent.GetType().Name].Handle(domainEvent);
        }

        return Task.CompletedTask;
    }

    public Task Register(string eventName, IEventHandler handler)
    {
        if (!_handlers.Any(x => x.ContainsKey(eventName)))
            _handlers.Add(new Dictionary<string, IEventHandler> { { eventName, handler } });
        return Task.CompletedTask;
    }

    public Task Unregister(string eventName, IEventHandler handler)
    {
        if (_handlers.Any(x => x.ContainsKey(eventName)))
            _handlers.First(x => x.ContainsKey(eventName)).Remove(eventName);
        return Task.CompletedTask;
    }

    public Task UnregisterAll()
    {
        _handlers = [];
        return Task.CompletedTask;
    }
}