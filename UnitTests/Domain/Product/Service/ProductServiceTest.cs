using Application.Domain.Product.Service;

namespace UnitTests.Domain.Product.Service;

public class ProductServiceTest
{
    [Fact]
    public void ShouldChangePriceOfAllProducts()
    {
        var product1 = new Application.Domain.Product.Entity.Product("1", "Product 1", 100);
        var product2 = new Application.Domain.Product.Entity.Product("2", "Product 2", 200);
        var products = new List<Application.Domain.Product.Entity.Product>() { product1, product2 };

        ProductService.ChangePriceOfAllProducts(products, 100);

        Assert.True(product1.GetPrice() == 200);
        Assert.True(product2.GetPrice() == 400);
    }
}