using Application.Domain.Customer.Event;
using Application.Domain.Customer.Event.Handler;

namespace UnitTests.Domain.Customer.Event.Handler;

public class LogWhenCustomerIsCreatedHandlerTest
{
    [Fact]
    public async Task Handle_ShouldCompleteSuccessfully()
    {
        // Arrange
        var handler = new LogWhenCustomerIsCreatedHandler();
        var domainEvent = new CustomerCreatedEvent("Test");

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
        var handler = new LogWhenCustomerIsCreatedHandler();
        var domainEvent = new CustomerCreatedEvent("Test");

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => handler.Handle(domainEvent));
        Assert.Null(exception);
    }
}