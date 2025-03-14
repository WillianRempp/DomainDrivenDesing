namespace Application.Domain.Entity
{
    public class Order
    {
        private string Id { get; }
        //Relationship with other aggregate should use id:
        private string CostumerId { get; }
        //Relationship in the same aggregate should use the object:
        private List<OrderItem> Items { get; }

        private decimal Total { get; }

        public Order(string id, string costumerId, List<OrderItem> items)
        {
            Id = id;
            CostumerId = costumerId;
            Items = items;
            Total = CalculateTotal();

            Validate();
        }

        private decimal CalculateTotal()
        {
            return Items.Sum(x => x.GetPrice());
        }

        public decimal GetTotal()
        {
            return Total;
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Id is required");
            }

            if (string.IsNullOrEmpty(CostumerId))
            {
                throw new Exception("CostumerId is required");
            }

            if (Items.Count == 0)
            {
                throw new Exception("Items is required");
            }
        }
    }
}