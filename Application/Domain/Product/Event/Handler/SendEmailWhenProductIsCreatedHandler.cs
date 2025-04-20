using Application.Domain.shared.Event;

namespace Application.Domain.Product.Event.Handler;

public class SendEmailWhenProductIsCreatedHandler : IEventHandler
{
    public virtual Task Handle(DomainEvent domainEvent)
    {
        Console.WriteLine("Sending email to ....");
        return Task.CompletedTask;
    }
}