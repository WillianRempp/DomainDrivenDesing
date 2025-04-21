using Application.Domain.Checkout.Entity;

namespace Application.Domain.Checkout.Factory;

public static class OrderFactory
{
    public static IOrder Create(string id, string costumerId, List<OrderItem> items)
    {
        return new Order(id, costumerId, items);
    }
}