using Application.Domain.Customer.Event;
using Application.Domain.Product.Event;
using Application.Domain.Product.Event.Handler;

namespace UnitTests.Domain.Product.Event.Handler;

public class LogWhenProductIsCreatedHandlerTest
{
    [Fact]
    public async Task Handle_ShouldCompleteSuccessfully()
    {
        // Arrange
        var handler = new SendEmailWhenProductIsCreatedHandler();
        var domainEvent = new ProductCreatedEvent("Test");

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
        var handler = new SendEmailWhenProductIsCreatedHandler();
        var domainEvent = new ProductCreatedEvent("Test");

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => handler.Handle(domainEvent));
        Assert.Null(exception);
    }
}