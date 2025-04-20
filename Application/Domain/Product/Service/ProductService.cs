using Application.Domain.Product.Entity;

namespace Application.Domain.Product.Service;

public abstract class ProductService
{
    public static void ChangePriceOfAllProducts(List<IProduct> products, decimal percentage)
    {
        foreach (var product in products)
        {
            product.ChangePrice(product.GetPrice() * percentage / 100 + product.GetPrice());
        }
    }
}