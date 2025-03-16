using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("Products")]
public class ProductModel
{
    [Key] public required string Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required decimal Price { get; set; }
}