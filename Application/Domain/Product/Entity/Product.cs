namespace Application.Domain.Product.Entity;

public sealed class Product : IProduct
{
    private string Id { get; }
    private string Name { get; set; }
    private decimal Price { get; set; }

    internal Product(string id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Id))
        {
            throw new Exception("Id is required");
        }

        if (string.IsNullOrEmpty(Name))
        {
            throw new Exception("Name is required");
        }

        if (Price <= 0)
        {
            throw new Exception("Price is required");
        }
    }

    public void ChangeName(string name)
    {
        Name = name;

        Validate();
    }

    public decimal GetPrice()
    {
        return Price;
    }

    public string GetName()
    {
        return Name;
    }

    public void ChangePrice(decimal price)
    {
        Price = price;
        Validate();
    }

    public string GetId()
    {
        return Id;
    }
}