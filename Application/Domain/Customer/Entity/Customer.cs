using Application.Domain.Customer.ValueObject;

namespace Application.Domain.Customer.Entity;

public class Customer : ICustomer
{
    private string Id { get; }
    private string Name { get; set; }
    private Address Address { get; set; }
    private bool Active { get; set; } = false;
    private int RewardPoints { get; set; } = 0;

    internal Customer(string id, string name)
    {
        Id = id;
        Name = name;
        Validate();
    }
    
    public Customer(string id, string name,Address address)
    {
        Id = id;
        Name = name;
        Address = address;
        Validate();
    }

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }

    public string GetId()
    {
        return Id;
    }

    public void Activate()
    {
        Active = true;
        if (Address == null)
        {
            throw new Exception("Address is required");
        }
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void AddAddress(Address address)
    {
        Address = address;
    }

    public Address GetAddress()
    {
        return Address;
    }

    public string GetName()
    {
        return Name;
    }

    public bool IsActive()
    {
        return Active;
    }

    public void AddRewardsPoints(int points)
    {
        RewardPoints += points;
    }

    public int GetRewardsPoints()
    {
        return RewardPoints;
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
    }
}