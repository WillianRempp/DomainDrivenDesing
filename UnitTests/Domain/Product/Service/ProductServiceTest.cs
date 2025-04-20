using Application.Domain.Product.Entity;
using Application.Domain.Product.Factory;
using Application.Domain.Product.Service;

namespace UnitTests.Domain.Product.Service;

public class ProductServiceTest
{
    [Fact]
    public void ShouldChangePriceOfAllProducts()
    {
        var product1 = ProductFactory.Create("a", "1", "Product 1", 100);
        var product2 = ProductFactory.Create("a", "2", "Product 2", 200);
        var products = new List<IProduct>() { product1, product2 };

        ProductService.ChangePriceOfAllProducts(products, 100);

        Assert.True(product1.GetPrice() == 200);
        Assert.True(product2.GetPrice() == 400);
    }
}