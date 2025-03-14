using Application.Domain.Entity;

namespace Application.Domain.Service
{
    public class OrderService
    {
        static public decimal total(List<Order> orders)
        {
            decimal total = 0;
            foreach (var order in orders)
            {
                total += order.GetTotal();
            }

            return total;
        }

        static public Order PlaceOrder(Customer customer, List<OrderItem> items)
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
}