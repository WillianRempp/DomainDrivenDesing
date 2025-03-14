using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entity
{
    public class Address
    {
        [Required] private string Street { get; }
        [Required] private string Number { get; }
        [Required] private string ZipCode { get; }
        [Required] private string City { get; }

        public Address(string street, string number, string zipCode, string city)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }

        public override string ToString()
        {
            return $"{Street}, {Number}, {ZipCode}, {City}";
        }
    }
}