using Application.Domain.Customer.Entity;
using Application.Domain.Customer.ValueObject;

namespace Application.Domain.Customer.Factory;

public static class CustomerFactory
{
    public static ICustomer Create(string nome)
    {
        return new Entity.Customer(Guid.NewGuid().ToString(), nome);
    }

    public static ICustomer CreateWithAddress(string name, Address address)
    {
        return new Entity.Customer(Guid.NewGuid().ToString(), name, address);
    }
    
    public static ICustomer CreateWithIdAndAddress(string id,string name, Address address)
    {
        return new Entity.Customer(id, name, address);
    }
}