using Application.Domain.Customer.Event;
using Application.Domain.Customer.Event.Handler;

namespace UnitTests.Domain.Customer.Event.Handler;

public class LogWhenCustomerIsUpdatedHandlerTest
{
    [Fact]
    public async Task Handle_ShouldCompleteSuccessfully()
    {
        // Arrange
        var handler = new LogWhenCustomerIsUpdatedHandler();

        var domainEvent = new CustomerUpdatedEvent("Test");

        // Act
        var task = handler.Handle(domainEvent);

        // Assert
        await Assert.IsAssignableFrom<Task>(task);
        Assert.True(task.IsCompletedSuccessfully);
    }
    
    [Fact]
    public async Task Handle_ShouldNotThrowException()
    {
        // Arrange
        var handler = new LogWhenCustomerIsUpdatedHandler();
        var domainEvent = new CustomerUpdatedEvent("Test");

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => handler.Handle(domainEvent));
        Assert.Null(exception);
    }
}