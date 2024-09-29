using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Domain.Entity
{
    public class Product
    {
        private string Id { get; }
        private string Name { get; set; }
        private decimal Price { get; set; }

        public Product(string id, string name, decimal price)
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

        internal string GetId()
        {
            return Id;
        }
    }
}