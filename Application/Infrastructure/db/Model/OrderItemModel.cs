using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("OrderItems")]
public class OrderItemModel
{
    [Key] public required string Id { get; set; }
    [Required] [ForeignKey("ProductId")] public required string ProductId { get; set; }
    [Required] [ForeignKey("OrderId")] public required string OrderId { get; set; }
    // [Required] public required OrderModel Order { get; set; }
    [Required] public required int Quantity { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required decimal Price { get; set; }
    
}