using Application.Domain.Entity;

namespace Application.Infrastructure.db.Model.Mapper;

public class CustomerMapper
{
    public static CustomerModel ToModel(Customer customer)
    {
        return new CustomerModel()
        {
            Id = customer.GetId(),
            Name = customer.GetName(),
            Address = ToModel(customer.GetAddress()),
            Active = customer.IsActive(),
            RewardPoints = customer.GetRewardsPoints()
        };
    }

    public static AddressModel ToModel(Address address)
    {
        return new AddressModel()
        {
            Street = address.GetStreet(),
            Number = address.GetNumber(),
            ZipCode = address.GetZipCode(),
            City = address.GetCity()
        };
    }

    public static Customer ToEntity(CustomerModel customerModel)
    {
        var customer = new Customer(customerModel.Id, customerModel.Name);
        customer.AddRewardsPoints(customerModel.RewardPoints);
        customer.AddAddress(ToEntity(customerModel.Address));
        return customer;
    }

    public static Address ToEntity(AddressModel addressModel)
    {
        return new Address(addressModel.Street, addressModel.Number, addressModel.ZipCode, addressModel.City);
    }
}