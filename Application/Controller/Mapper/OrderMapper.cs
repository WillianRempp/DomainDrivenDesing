using Application.Controller.Dto;
using Application.Domain.Checkout.Entity;

namespace Application.Controller.Mapper;

public static class OrderMapper
{
    public static Order ToEntity(OrderDto orderDto)
    {
        var orderItems = orderDto.Items
            .Select(item => new OrderItem(orderDto.Id, item.Name, item.Price, item.ProductId, item.Quantity)).ToList();
        return new Order(orderDto.Id, orderDto.CostumerId, orderItems);
    }

    public static OrderDto ToDto(Order order)
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