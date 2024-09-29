using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain.Entity;

namespace Application.Domain.Service
{
    public class ProductService
    {
        static public void ChangePriceOfAllProducts(List<Product> products, decimal percentage)
        {
            foreach (var product in products)
            {
                product.ChangePrice(product.GetPrice() * percentage / 100 + product.GetPrice());
            }
        }
    }
}