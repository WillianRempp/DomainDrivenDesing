using Application.Domain.Entity;
using Application.Domain.Repository;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.db.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly Context _context;

    public OrderRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(Order order, Customer customer)
    {
        await _context.OrderModel.AddAsync(
            new OrderModel
            {
                Id = order.GetId(),
                CustomerId = customer.GetId(),
                Items = order.GetItems().Select(orderItem => new OrderItemModel()
                    {
                        Id = orderItem.GetId(),
                        Name = orderItem.GetName(),
                        Price = orderItem.GetPrice(),
                        ProductId = orderItem.GetProductId(),
                        Quantity = orderItem.GetQuantity(),
                        OrderId = order.GetId()
                    })
                    .ToList(),
                Total = order.GetTotal()
            });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var orderModel = _context.OrderModel.FirstOrDefault(x => x.Id == id);
        if (orderModel != null)
        {
            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Order>> FindAllAsync()
    {
        var orders = _context.OrderModel.Select(x => new Order(x.Id, x.CustomerId,
            x.Items.Select(orderItem => new OrderItem(orderItem.Id, orderItem.Name, orderItem.Price,
                orderItem.ProductId, orderItem.Quantity)).ToList())).ToList();
        return Task.FromResult(orders);
    }


    public async Task<Order?> FindByIdAsync(string id)
    {
        var orderModel = await _context.OrderModel.FirstOrDefaultAsync(x => x.Id == id);
        if (orderModel == null)
        {
            return null;
        }

        return new Order(orderModel.Id, orderModel.CustomerId,
            orderModel.Items.Select(orderItem => new OrderItem(orderItem.Id, orderItem.Name, orderItem.Price,
                orderItem.ProductId, orderItem.Quantity)).ToList());
    }


    public Task CreateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Order?> UpdateAsync(Order entity)
    {
        var existingOrder = _context.OrderModel.FirstOrDefault(x => x.Id == entity.GetId());
        if (existingOrder == null)
        {
            return null;
        }

        existingOrder.Total = entity.GetTotal();
        await _context.SaveChangesAsync();
        return new Order(existingOrder.Id, existingOrder.CustomerId,
            existingOrder.Items.Select(orderItem => new OrderItem(orderItem.Id, orderItem.Name, orderItem.Price,
                orderItem.ProductId, orderItem.Quantity)).ToList());
    }
}