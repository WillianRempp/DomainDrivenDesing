using Application.Domain.Product.Factory;

namespace UnitTests.Domain.Product.Entity;

public class ProductTest
{
    [Fact]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => ProductFactory.Create("a", "", "1", 100));
        Assert.Equal("Id is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenNameIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => ProductFactory.Create("a", "1", "", 100));
        Assert.Equal("Name is required", actualException.Message);
    }

    [Fact]
    public void ShouldThrowErrorWhenPriceIsEmpty()
    {
        var actualException = Assert.Throws<Exception>(() => ProductFactory.Create("a", "1", "1", -1));
        Assert.Equal("Price is required", actualException.Message);
    }

    [Fact]
    public void ShouldChangeName()
    {
        var customer = ProductFactory.Create("a", "1", "Product 1", 100);
        customer.ChangeName("Product 2");
        Assert.Equal("Product 2", customer.GetName());
    }
}