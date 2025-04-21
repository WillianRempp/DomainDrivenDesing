using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;

namespace UnitTests.Domain.Customer.Factory;

public class CustomerFactoryTests
{
    [Fact]
    public void Create_ShouldReturnCustomerWithValidIdAndName()
    {
        // Arrange
        var name = "João";

        // Act
        var customer = CustomerFactory.Create(name);

        // Assert
        Assert.IsType<Application.Domain.Customer.Entity.Customer>(customer);
        Assert.False(string.IsNullOrWhiteSpace(customer.GetId()));
        Assert.Equal(name, customer.GetName());
    }

    [Fact]
    public void CreateWithAddress_ShouldReturnCustomerWithAddress()
    {
        // Arrange
        var name = "Maria";
        var address = new Address("Rua A", "123", "12345-000", "SP");

        // Act
        var customer = CustomerFactory.CreateWithAddress(name, address);

        // Assert
        Assert.IsType<Application.Domain.Customer.Entity.Customer>(customer);
        Assert.Equal(name, customer.GetName());
        Assert.Equal(address, customer.GetAddress());
    }

    [Fact]
    public void CreateWithIdAndAddress_ShouldReturnCustomerWithGivenIdAndAddress()
    {
        // Arrange
        var id = "123";
        var name = "Carlos";
        var address = new Address("Av. B", "456", "22222-000", "RJ");

        // Act
        var customer = CustomerFactory.CreateWithIdAndAddress(id, name, address);

        // Assert
        Assert.IsType<Application.Domain.Customer.Entity.Customer>(customer);
        Assert.Equal(id, customer.GetId());
        Assert.Equal(name, customer.GetName());
        Assert.Equal(address, customer.GetAddress());
    }
}