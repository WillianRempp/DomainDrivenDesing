using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("Customers")]
public class CustomerModel
{
    [Key] public required string Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required AddressModel Address { get; set; }
    [Required] public required bool Active { get; set; }
    [Required] public required int RewardPoints { get; set; }
}

[Table("Addresses")]
public class AddressModel
{
    [Key] public required string Id { get; set; }
    [Required] public required string Street { get; set; }
    [Required] public required string Number { get; set; }
    [Required] public required string ZipCode { get; set; }
    [Required] public required string City { get; set; }
}