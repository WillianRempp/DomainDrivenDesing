using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;

namespace UnitTests.Domain.Customer.Entity;

public class CustomerTest
{
    [Fact]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() =>
            CustomerFactory.CreateWithIdAndAddress("", "Willian",
                new Address("Rua dos bobos", "0", "00000-000", "Jundiai")));
        Assert.Equal("Id is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenIdNameIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => CustomerFactory.Create(""));
        Assert.Equal("Name is required", actualException.Message);
    }

    [Fact]
    public void ShouldChangeName()
    {
        var customer = CustomerFactory.Create("Willian");
        customer.ChangeName("Will");
        Assert.Equal("Will", customer.GetName());
    }

    [Fact]
    public void ShouldActivate()
    {
        var customer =
            CustomerFactory.CreateWithAddress("Willian", new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer.Activate();
        Assert.True(customer.IsActive());
    }

    [Fact]
    public void ShouldThrowErrorWhenAddresIsUndefined()
    {
        var customer = CustomerFactory.Create("Willian");

        Assert.Throws<Exception>(() => customer.Activate()).Message.Equals("Address is required");
    }

    [Fact]
    public void ShouldDeactivate()
    {
        var customer = CustomerFactory.Create("Willian");
        customer.Deactivate();
        Assert.False(customer.IsActive());
    }

    [Fact]
    public void ShouldAddRewardPoints()
    {
        var customer = CustomerFactory.Create("Willian");
        Assert.Equal(0, customer.GetRewardsPoints());
        customer.AddRewardsPoints(10);
        Assert.Equal(10, customer.GetRewardsPoints());
    }
}