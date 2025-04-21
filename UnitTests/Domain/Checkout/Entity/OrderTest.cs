using Application.Domain.Checkout.Entity;
using Application.Domain.Checkout.Factory;

namespace UnitTests.Domain.Checkout.Entity;

public class OrderTest
{
    [Fact]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => OrderFactory.Create("", "", new List<OrderItem>()));
        Assert.Equal("Id is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenCustomerIdIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => OrderFactory.Create("1", "", new List<OrderItem>()));
        Assert.Equal("CostumerId is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorOrderItemsIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => OrderFactory.Create("1", "1", new List<OrderItem>()));
        Assert.Equal("Items is required", actualException.Message);
    }


    [Fact]
    public void ShouldCalculateTotal()
    {
        var order = OrderFactory.Create("1", "1", [new("1", "Item 1", 10, "1", 2), new("12", "Item 12", 10, "1", 1)]);
        Assert.Equal(30, order.GetTotal());
    }

    [Fact]
    public void ShouldThrowErrorIfQuantityIsZero()
    {
        var actualException = Assert.Throws<Exception>(() =>
            OrderFactory.Create("`ProductId", "ProductName", [new("1", "Item 1", 10, "1", 0)]));
        Assert.Equal("Quantity is required", actualException.Message);
    }
}