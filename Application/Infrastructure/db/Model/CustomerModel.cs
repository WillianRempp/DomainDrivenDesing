using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("Product")]
public class CustomerModel
{
    [Key] public required string Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public AddressModel Address { get; set; }
    [Required] public bool Active { get; set; }
    [Required] public int RewardPoints { get; set; }
}

public class AddressModel
{
    [Required] public string Street { get; set; }
    [Required] public string Number { get; set; }
    [Required] public string ZipCode { get; set; }
    [Required] public string City { get; set; }
}