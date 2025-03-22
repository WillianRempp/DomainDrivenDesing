using System.ComponentModel.DataAnnotations;

namespace Application.Controller.Dto;

public class OrderDto
{
    [Required] public string Id { get; set; }
    [Required] public string CostumerId { get; set; }
    [Required] public List<OrderItemDto> Items { get; set; }
}

public class OrderItemDto
{
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] public int Quantity { get; set; }
    [Required] public string ProductId { get; set; }
}