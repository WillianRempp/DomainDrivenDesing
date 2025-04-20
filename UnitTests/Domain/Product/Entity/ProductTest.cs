namespace UnitTests.Domain.Product.Entity;

public class ProductTest
{
    [Fact]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        Exception actualException = Assert.Throws<Exception>(() => new Application.Domain.Product.Entity.Product("", "1", 100));
        Assert.Equal("Id is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenNameIsEmpty()
    {
        Exception actualException = Assert.Throws<Exception>(() => new Application.Domain.Product.Entity.Product("1", "", 100));
        Assert.Equal("Name is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenPriceIsEmpty()
    {
        Exception actualException = Assert.Throws<Exception>(() => new Application.Domain.Product.Entity.Product("1", "1", -1));
        Assert.Equal("Price is required", actualException.Message);
    }

    [Fact]
    public void ShouldChangeName()
    {
        var customer = new Application.Domain.Product.Entity.Product("1", "Product 1", 100);
        customer.ChangeName("Product 2");
        Assert.Equal("Product 2", customer.GetName());
    }
}