using Application.Controller.Dto;
using Application.Domain.Entity;

namespace Application.Controller.Mapper;

public static class OrderMapper
{
    public static Order ToEntity(OrderDto orderDto)
    {
        var orderItems = orderDto.Items
            .Select(item => new OrderItem(orderDto.Id, item.Name, item.Price, item.ProductId, item.Quantity)).ToList();
        return new Order(orderDto.Id, orderDto.CostumerId, orderItems);
    }
}