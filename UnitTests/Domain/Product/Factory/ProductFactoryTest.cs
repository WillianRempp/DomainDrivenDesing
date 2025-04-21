using Application.Domain.Product.Entity;
using Application.Domain.Product.Factory;

namespace UnitTests.Domain.Product.Factory;

public class ProductFactoryTests
{
    [Fact]
    public void Create_WithTypeA_ShouldReturnProduct()
    {
        // Arrange
        var type = "a";
        var id = "1";
        var name = "Produto A";
        var price = 10m;

        // Act
        var product = ProductFactory.Create(type, id, name, price);

        // Assert
        Assert.IsType<Application.Domain.Product.Entity.Product>(product);
        Assert.Equal(id, product.GetId());
        Assert.Equal(name, product.GetName());
        Assert.Equal(price, product.GetPrice());
    }

    [Fact]
    public void Create_WithTypeB_ShouldReturnProductB()
    {
        // Arrange
        var type = "b";
        var id = "2";
        var name = "Produto B";
        var price = 20m;

        // Act
        var product = ProductFactory.Create(type, id, name, price);

        // Assert
        Assert.IsType<ProductB>(product);
        Assert.Equal(id, product.GetId());
        Assert.Equal(name, product.GetName());
        Assert.Equal(price, product.GetPrice());
    }

    [Fact]
    public void Create_WithInvalidType_ShouldThrowException()
    {
        // Arrange
        var type = "x";
        var id = "3";
        var name = "Produto X";
        var price = 30m;

        // Act & Assert
        var exception = Assert.Throws<Exception>(() =>
            ProductFactory.Create(type, id, name, price));

        Assert.Equal("Invalid product type", exception.Message);
    }
}