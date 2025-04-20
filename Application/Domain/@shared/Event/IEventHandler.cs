namespace Application.Domain.shared.Event;

public interface IEventHandler
{
    Task Handle(DomainEvent domainEvent);
}