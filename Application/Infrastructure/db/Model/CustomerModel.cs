using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Infrastructure.db.Model;

[Table("Customers")]
public class CustomerModel
{
    [Key] public required string Id { get; set; }
    public required string Name { get; set; }
    public required AddressModel Address { get; set; }
    public required bool Active { get; set; }
    public required int RewardPoints { get; set; }
}

[Table("Addresses")]
public class AddressModel
{
    [Key] public required string Id { get; set; }

    public required string CustomerId { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string ZipCode { get; set; }
    public required string City { get; set; }
}