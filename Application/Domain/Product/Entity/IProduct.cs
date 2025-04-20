namespace Application.Domain.Product.Entity;

public interface IProduct
{
    void ChangeName(string name);
    decimal GetPrice();
    string GetName();
    void ChangePrice(decimal price);
    string GetId();
}