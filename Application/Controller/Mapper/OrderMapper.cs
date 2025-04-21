using Application.Controller.Dto;
using Application.Domain.Checkout.Entity;
using Application.Domain.Checkout.Factory;

namespace Application.Controller.Mapper;

public static class OrderMapper
{
    public static IOrder ToEntity(OrderDto orderDto)
    {
        var orderItems = orderDto.Items
            .Select(item => new OrderItem(orderDto.Id, item.Name, item.Price, item.ProductId, item.Quantity)).ToList();
        return OrderFactory.Create(orderDto.Id, orderDto.CostumerId, orderItems);
    }

    public static OrderDto ToDto(IOrder order)
    {
        var orderItems = order.GetItems()
            .Select(item => new OrderItemDto()
            {
                Name = item.GetName(), Price = item.GetPrice(), ProductId = item.GetProductId(),
                Quantity = item.GetQuantity()
            }).ToList();
        return new OrderDto() { Id = order.GetId(), CostumerId = order.GetCostumerId(), Items = orderItems };
    }
}