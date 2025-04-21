using Application.Domain.Checkout.Entity;
using Application.Domain.Checkout.Service;
using Application.Domain.Customer.Factory;

namespace UnitTests.Domain.Checkout.Service;

public class OrderServiceTest
{
    [Fact]
    public void ShouldGetTotalOfAllOrders()
    {
        var orderItem1 = new OrderItem("1", "Item 1", 10, "1", 1);
        var order1 = new Order("1", "1", [orderItem1]);
        var orderItem2 = new OrderItem("2", "Item 2", 10, "1", 2);
        var order2 = new Order("2", "2", [orderItem2]);

        var orders = OrderService.Total([order1, order2]);
        Assert.Equal(30, orders);
    }

    [Fact]
    public void ShouldPlaceAnOrder()
    {
        var costumer = CustomerFactory.Create( "Customer 1");

        var orderItem1 = new OrderItem("1", "Item 1", 10, "1", 1);
        var order = OrderService.PlaceOrder(costumer, [orderItem1]);

        Assert.True(costumer.GetRewardsPoints() == 5);
        Assert.True(order.GetTotal() == 10);
    }
}