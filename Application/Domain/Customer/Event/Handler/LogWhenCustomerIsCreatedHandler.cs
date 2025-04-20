using Application.Domain.shared.Event;

namespace Application.Domain.Customer.Event.Handler;

public class LogWhenCustomerIsCreatedHandler : IEventHandler
{
    public virtual Task Handle(DomainEvent domainEvent)
    {
        Console.WriteLine("Esse é o primeiro console.log do evento: CustomerCreated");
        return Task.CompletedTask;
    }
}