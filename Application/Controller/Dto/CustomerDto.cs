using System.ComponentModel.DataAnnotations;

namespace Application.Controller.Dto;

public class CustomerDto
{
    [Required]
    public string Id { get; set; }   
    [Required]
    public string Name { get; set; }
    [Required]
    public AddressDto Address { get; set; }
}

public class AddressDto
{
    [Required]
    public string Street { get; set; }
    [Required]
    public string Number { get; set; }
    [Required]
    public string ZipCode { get; set; }
    [Required]
    public string City { get; set; }
}
