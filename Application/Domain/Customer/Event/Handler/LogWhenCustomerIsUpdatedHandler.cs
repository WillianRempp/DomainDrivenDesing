using Application.Domain.shared.Event;

namespace Application.Domain.Customer.Event.Handler;

public class LogWhenCustomerIsUpdatedHandler : IEventHandler
{
    public virtual Task Handle(DomainEvent domainEvent)
    {
        Console.WriteLine("Esse é o segundo console.log do evento: CustomerCreated");
        return Task.CompletedTask;
    }
}