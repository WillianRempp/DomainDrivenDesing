using Application.Domain.Entity;
using Application.Domain.Service;

namespace UnitTests.Service;

public class ProductServiceTest
{
    [Fact]
    public void ShouldChangePriceOfAllProducts()
    {
        var product1 = new Product("1", "Product 1", 100);
        var product2 = new Product("2", "Product 2", 200);
        var products = new List<Product>() { product1, product2 };

        ProductService.ChangePriceOfAllProducts(products, 100);

        Assert.True(product1.GetPrice() == 200);
        Assert.True(product2.GetPrice() == 400);
    }
}