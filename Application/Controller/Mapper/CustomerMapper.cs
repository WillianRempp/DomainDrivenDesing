using Application.Controller.Dto;
using Application.Domain.Customer.Entity;
using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;

namespace Application.Controller.Mapper;

public static class CustomerMapper
{
    public static ICustomer ToEntity(CustomerDto customerDto)
    {
        return CustomerFactory.CreateWithIdAndAddress(customerDto.Id, customerDto.Name, AddressToEntity(customerDto.Address));
    }
    
    public static CustomerDto ToDto(ICustomer customer)
    {
        return new CustomerDto()
        {
            Id = customer.GetId(),
            Name = customer.GetName(),
            Address = AddressToDto(customer.GetAddress())
        };
    }
    
    public static Address AddressToEntity(AddressDto customerDto)
    {
        return new Address(customerDto.Street, customerDto.Number, customerDto.ZipCode, customerDto.City);
    }
    
    public static AddressDto AddressToDto(Address customer)
    {
        return new AddressDto()
        {
            Street = customer.GetStreet(),
            Number = customer.GetNumber(),
            ZipCode = customer.GetZipCode(),
            City = customer.GetCity(),
        };
    }
}