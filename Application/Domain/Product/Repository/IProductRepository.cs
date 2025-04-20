using Application.Domain.shared.Repository;

namespace Application.Domain.Product.Repository;

public interface IProductRepository : IRepository<Product.Entity.Product>
{
}