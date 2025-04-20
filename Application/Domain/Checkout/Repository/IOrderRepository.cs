using Application.Domain.Checkout.Entity;
using Application.Domain.shared.Repository;

namespace Application.Domain.Checkout.Repository;

public interface IOrderRepository : IRepository<Order>
{
    Task CreateOrderAsync(Order order, Customer.Entity.Customer customer);
}