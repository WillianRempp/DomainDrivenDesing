using Application.Domain.Checkout.Entity;
using Application.Domain.Checkout.Factory;
using Application.Domain.Checkout.Repository;
using Application.Domain.Customer.Entity;
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

    public async Task CreateOrderAsync(IOrder order, ICustomer customer)
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
        var orderModel = await _context.OrderModel.FirstOrDefaultAsync(x => x.Id == id);
        if (orderModel != null)
        {
            _context.OrderModel.Remove(orderModel);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<IOrder>> FindAllAsync()
    {
        var orders = _context.OrderModel.Select(x => OrderFactory.Create(x.Id, x.CustomerId,
            x.Items.Select(orderItem => new OrderItem(orderItem.Id, orderItem.Name, orderItem.Price,
                orderItem.ProductId, orderItem.Quantity)).ToList())).ToList();
        return Task.FromResult(orders);
    }


    public async Task<IOrder?> FindByIdAsync(string id)
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

    public async Task CreateAsync(IOrder entity)
    {
        await _context.OrderModel.AddAsync(
            new OrderModel()
            {
                Id = entity.GetId(),
                CustomerId = entity.GetCostumerId(),
                Items = entity.GetItems().Select(orderItem => new OrderItemModel()
                {
                    Id = orderItem.GetId(),
                    Name = orderItem.GetName(),
                    Price = orderItem.GetPrice(),
                    ProductId = orderItem.GetProductId(),
                    Quantity = orderItem.GetQuantity(),
                    OrderId = entity.GetId()
                }).ToList(),
                Total = entity.GetTotal()
            });
        await _context.SaveChangesAsync();
    }

    public async Task<IOrder?> UpdateAsync(IOrder entity)
    {
        var existingOrder = await _context.OrderModel.FirstOrDefaultAsync(x => x.Id == entity.GetId());
        if (existingOrder == null)
        {
            return null;
        }

        existingOrder.Total = entity.GetTotal();
        await _context.SaveChangesAsync();
        return OrderFactory.Create(existingOrder.Id, existingOrder.CustomerId,
            existingOrder.Items.Select(orderItem => new OrderItem(orderItem.Id, orderItem.Name, orderItem.Price,
                orderItem.ProductId, orderItem.Quantity)).ToList());
    }
}