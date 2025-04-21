using Application.Domain.Customer.ValueObject;

namespace Application.Domain.Customer.Entity;

public interface ICustomer
{
    void ChangeName(string name);
    string GetId();
    void Activate();
    void Deactivate();
    void AddAddress(Address address);
    Address GetAddress();
    string GetName();
    bool IsActive();
    void AddRewardsPoints(int points);
    int GetRewardsPoints();
}