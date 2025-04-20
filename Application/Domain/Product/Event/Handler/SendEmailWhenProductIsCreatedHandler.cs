using Application.Domain.shared;

namespace Application.Domain.Product.Event.Handler;

public class SendEmailWhenProductIsCreatedHandler : IEventHandler
{
    public virtual Task Handle(shared.Event @event)
    {
        Console.WriteLine("Sending email to ....");
        return Task.CompletedTask;
    }
}