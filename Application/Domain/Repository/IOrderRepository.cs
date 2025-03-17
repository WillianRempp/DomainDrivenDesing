using Application.Domain.Entity;

namespace Application.Domain.Repository;

public interface IOrderRepository : IRepository<Order>
{
    Task CreateOrderAsync(Order order, Customer customer);
}