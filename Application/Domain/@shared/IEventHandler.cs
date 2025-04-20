namespace Application.Domain.shared;

public interface IEventHandler
{
    Task Handle(Event @event);
}