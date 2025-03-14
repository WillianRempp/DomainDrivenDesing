using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model
{
    [Table("Product")]
    public class ProductModel
    {
        [Key] public required string Id { get; set; }
        [Required] public required string Name { get; set; }
        [Required] public decimal Price { get; set; }
    }
}