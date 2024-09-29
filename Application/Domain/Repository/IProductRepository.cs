using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain.Entity;

namespace Application.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}