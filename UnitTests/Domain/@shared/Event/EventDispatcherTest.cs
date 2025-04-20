using Application.Domain.Product.Event;
using Application.Domain.Product.Event.Handler;
using Application.Domain.shared.Event;
using Moq;

namespace UnitTests.Domain.shared.Event;

public class EventDispatcherTest
{
    [Fact]
    public async Task ShouldRegisterAnEventHandler()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        await eventDispatcher.Register("DomainEvent", eventHandler);

        Assert.Contains(eventDispatcher.GetEventHandlers(), x => x.ContainsKey("DomainEvent"));
        Assert.True(eventDispatcher.GetEventHandlers()[0]["DomainEvent"].Equals(eventHandler));
    }

    [Fact]
    public async Task ShouldUnregisterAnEventHandler()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        await eventDispatcher.Register("DomainEvent", eventHandler);


        Assert.Contains(eventDispatcher.GetEventHandlers(), x => x.ContainsKey("DomainEvent"));
        Assert.True(eventDispatcher.GetEventHandlers()[0]["DomainEvent"].Equals(eventHandler));

        eventDispatcher.Unregister("DomainEvent", eventHandler);

        Assert.DoesNotContain(eventDispatcher.GetEventHandlers(), x => x.ContainsKey("DomainEvent"));
    }

    [Fact]
    public async Task ShouldUnregisterAllEventHandlers()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        await eventDispatcher.Register("DomainEvent", eventHandler);


        Assert.Contains(eventDispatcher.GetEventHandlers(), x => x.ContainsKey("DomainEvent"));
        Assert.True(eventDispatcher.GetEventHandlers()[0]["DomainEvent"].Equals(eventHandler));

        await eventDispatcher.UnregisterAll();

        Assert.Empty(eventDispatcher.GetEventHandlers());
    }

    [Fact]
    public async Task ShouldNotifyEventHandlers()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandlerMock = new Mock<SendEmailWhenProductIsCreatedHandler>();

        await eventDispatcher.Register("ProductCreatedEvent", eventHandlerMock.Object);

        await eventDispatcher.Notify(new ProductCreatedEvent("ProductCreatedEvent"));

        eventHandlerMock.Verify(handle => handle.Handle(It.IsAny<DomainEvent>()), Times.Once);
    }
}