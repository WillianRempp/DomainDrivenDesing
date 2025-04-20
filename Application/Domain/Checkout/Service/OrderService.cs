using Application.Domain.Checkout.Entity;

namespace Application.Domain.Checkout.Service;

public abstract class OrderService
{
    public static decimal Total(List<Order> orders)
    {
        return orders.Sum(order => order.GetTotal());
    }

    public static Order PlaceOrder(Customer.Entity.Customer customer, List<OrderItem> items)
    {
        if (items.Count <= 0)
        {
            throw new Exception("Items is required");
        }

        var order = new Order(new Guid().ToString(), customer.GetId(), items);
        customer.AddRewardsPoints((int)order.GetTotal() / 2);
        return order;
    }
}