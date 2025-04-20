using Application.Domain.Product.Event;
using Application.Domain.Product.Event.Handler;
using Application.Domain.shared;
using Moq;

namespace UnitTests.Event;

public class EventDispatcherTest
{
    [Fact]
    public void ShouldRegisterAnEventHandler()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);


        Assert.Contains(eventDispatcher.getEventHandlers(), x => x.ContainsKey("ProductCreatedEvent"));
        Assert.True(eventDispatcher.getEventHandlers().First()["ProductCreatedEvent"].Equals(eventHandler));
    }

    [Fact]
    public void ShouldUnregisterAnEventHandler()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);


        Assert.Contains(eventDispatcher.getEventHandlers(), x => x.ContainsKey("ProductCreatedEvent"));
        Assert.True(eventDispatcher.getEventHandlers().First()["ProductCreatedEvent"].Equals(eventHandler));

        eventDispatcher.Unregister("ProductCreatedEvent", eventHandler);

        Assert.DoesNotContain(eventDispatcher.getEventHandlers(), x => x.ContainsKey("ProductCreatedEvent"));
    }

    [Fact]
    public void ShouldUnregisterAllEventHandlers()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandler = new SendEmailWhenProductIsCreatedHandler();

        eventDispatcher.Register("ProductCreatedEvent", eventHandler);


        Assert.Contains(eventDispatcher.getEventHandlers(), x => x.ContainsKey("ProductCreatedEvent"));
        Assert.True(eventDispatcher.getEventHandlers().First()["ProductCreatedEvent"].Equals(eventHandler));

        eventDispatcher.UnregisterAll();

        Assert.Empty(eventDispatcher.getEventHandlers());
    }

    [Fact]
    public void ShouldNotifyEventHandlers()
    {
        var eventDispatcher = new EventDispatcher();
        var eventHandlerMock = new Mock<SendEmailWhenProductIsCreatedHandler>();

        eventDispatcher.Register("ProductCreatedEvent", eventHandlerMock.Object);

        eventDispatcher.Notify(new ProductCreatedEvent("ProductCreatedEvent"));

        eventHandlerMock.Verify(handle => handle.Handle(It.IsAny<Application.Domain.shared.Event>()), Times.Once);
    }
}