using Application.Domain.Product.Entity;

namespace Application.Domain.Product.Factory;

public class ProductFactory
{
    public static IProduct Create(string type, string id, string name, decimal price)
    {
        return type switch
        {
            "a" => new Entity.Product(id, name, price),
            "b" => new ProductB(id, name, price),
            _ => throw new Exception("Invalid product type")
        };
    }
}