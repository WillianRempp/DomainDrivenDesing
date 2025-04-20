namespace Application.Domain.shared;

public class EventDispatcher : IEventDispatcher
{
    private List<Dictionary<string, IEventHandler>> _handlers = [];

    public List<Dictionary<string, IEventHandler>> getEventHandlers()
    {
        return _handlers;
    }

    public Task Notify(Event @event)
    {
        foreach (var handler in
                 _handlers.Where(handler => handler.ContainsKey(@event.GetType().Name)))
        {
            handler[@event.GetType().Name].Handle(@event);
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