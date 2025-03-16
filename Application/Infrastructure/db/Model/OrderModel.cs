using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("Orders")]
public class OrderModel
{
    [Key] public required string Id { get; set; }
    [Required] [ForeignKey("CustomerId")] public required string CustomerId { get; set; }
    [Required] public required List<OrderItemModel> Items { get; set; }
    [Required] public required decimal Total { get; set; }
    
}