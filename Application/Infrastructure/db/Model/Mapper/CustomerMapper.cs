using Application.Domain.Customer.Entity;
using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;

namespace Application.Infrastructure.db.Model.Mapper;

public static class CustomerMapper
{
    public static CustomerModel ToModel(ICustomer customer)
    {
        return new CustomerModel()
        {
            Id = customer.GetId(),
            Name = customer.GetName(),
            Address = ToModel(customer.GetAddress(), customer.GetId()),
            Active = customer.IsActive(),
            RewardPoints = customer.GetRewardsPoints()
        };
    }

    public static AddressModel ToModel(Address address, string customerId)
    {
        return new AddressModel()
        {
            Id = Guid.NewGuid().ToString(),
            Street = address.GetStreet(),
            Number = address.GetNumber(),
            ZipCode = address.GetZipCode(),
            City = address.GetCity(),
            CustomerId = customerId
        };
    }

    public static ICustomer ToEntity(CustomerModel customerModel)
    {
        var customer = CustomerFactory.CreateWithIdAndAddress(customerModel.Id, customerModel.Name, ToEntity(customerModel.Address));
        customer.AddRewardsPoints(customerModel.RewardPoints);
        return customer;
    }

    public static Address ToEntity(AddressModel addressModel)
    {
        return new Address(addressModel.Street, addressModel.Number, addressModel.ZipCode, addressModel.City);
    }
}