using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Domain.Entity
{
    public class OrderItem
    {
        private string Id { get; }
        private string Name { get; set; }
        private decimal Price { get; set; }
        private string ProductId { get; }
        private int Quantity { get; }

        public OrderItem(string id, string name, decimal price, string productId, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductId = productId;
            Quantity = quantity;

            Validate();

        }

        private void Validate()
        {
            if (Quantity <= 0)
            {
                throw new Exception("Quantity is required");
            }
        }

        public decimal GetPrice()
        {
            return Price * Quantity;
        }
    }
}