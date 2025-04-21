namespace Application.Domain.Checkout.Entity;

public interface IOrder
{
    decimal GetTotal();
    List<OrderItem> GetItems();
    string GetId();
    string GetCostumerId();
}