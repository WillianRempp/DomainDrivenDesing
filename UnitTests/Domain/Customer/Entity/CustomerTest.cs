using Application.Domain.Customer.ValueObject;

namespace UnitTests.Domain.Customer.Entity;

public class CustomerTest
{
    [Fact]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        Exception actualException = Assert.Throws<Exception>(() => new Application.Domain.Customer.Entity.Customer("", "Willian"));
        Assert.Equal("Id is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenIdNameIsEmpty()
    {
        Exception actualException = Assert.Throws<Exception>(() => new Application.Domain.Customer.Entity.Customer("2", ""));
        Assert.Equal("Name is required", actualException.Message);
    }

    [Fact]
    public void ShouldChangeName()
    {
        var customer = new Application.Domain.Customer.Entity.Customer("1", "Willian");
        customer.ChangeName("Will");
        Assert.Equal("Will", customer.GetName());
    }

    [Fact]
    public void ShouldActivate()
    {
        var customer = new Application.Domain.Customer.Entity.Customer("1", "Willian");
        var address = new Address("Rua dos bobos", "0", "00000-000", "Jundiai");
        customer.AddAddress(address);
        customer.Activate();
        Assert.True(customer.IsActive());
    }

    [Fact]
    public void ShouldThrowErrorWhenAddresIsUndefined()
    {
        var customer = new Application.Domain.Customer.Entity.Customer("1", "Willian");

        Assert.Throws<Exception>(() => customer.Activate()).Message.Equals("Address is required");
    }

    [Fact]
    public void ShouldDeactivate()
    {
        var customer = new Application.Domain.Customer.Entity.Customer("1", "Willian");
        customer.Deactivate();
        Assert.False(customer.IsActive());
    }

    [Fact]
    public void ShouldAddRewardPoints()
    {
        var customer = new Application.Domain.Customer.Entity.Customer("1", "Willian");
        Assert.Equal(0, customer.GetRewardsPoints());
        customer.AddRewardsPoints(10);
        Assert.Equal(10, customer.GetRewardsPoints());
    }
}