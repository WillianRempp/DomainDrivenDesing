namespace Application.Domain.Product.Service;

public abstract class ProductService
{
    public static void ChangePriceOfAllProducts(List<Product.Entity.Product> products, decimal percentage)
    {
        foreach (var product in products)
        {
            product.ChangePrice(product.GetPrice() * percentage / 100 + product.GetPrice());
        }
    }
}