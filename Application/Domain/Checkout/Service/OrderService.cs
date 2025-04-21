using Application.Domain.Checkout.Entity;
using Application.Domain.Customer.Entity;

namespace Application.Domain.Checkout.Service;

public abstract class OrderService
{
    public static decimal Total(List<Order> orders)
    {
        return orders.Sum(order => order.GetTotal());
    }

    public static Order PlaceOrder(ICustomer customer, List<OrderItem> items)
    {
        if (items.Count <= 0)
        {
            throw new Exception("Items is required");
        }

        var order = new Order(Guid.NewGuid().ToString(), customer.GetId(), items);
        customer.AddRewardsPoints((int)order.GetTotal() / 2);
        return order;
    }
}