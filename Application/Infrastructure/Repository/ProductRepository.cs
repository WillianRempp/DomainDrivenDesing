using Application.Domain.Product.Entity;
using Application.Domain.Repository;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.db.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateAsync(Product entity)
    {
        await _context.ProductModel.AddAsync(
            new ProductModel
            {
                Id = entity.GetId(),
                Name = entity.GetName(),
                Price = entity.GetPrice()
            });
        _context.SaveChanges();
    }

    public async Task DeleteAsync(string id)
    {
        var productModel = _context.ProductModel.FirstOrDefault(x => x.Id == id);
        if (productModel != null)
        {
            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Product>> FindAllAsync()
    {
        var products = _context.ProductModel.Select(x => new Product(x.Id, x.Name, x.Price)).ToList();
        return Task.FromResult(products);
    }


    public async Task<Product?> FindByIdAsync(string id)
    {
        var productModel = await _context.ProductModel.FirstOrDefaultAsync(x => x.Id == id);
        if (productModel == null)
        {
            return null;
        }

        return new Product(productModel.Id, productModel.Name, productModel.Price);
    }


    public async Task<Product?> UpdateAsync(Product entity)
    {
        var existingProduct = _context.ProductModel.FirstOrDefault(x => x.Id == entity.GetId());
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = entity.GetName();
        existingProduct.Price = entity.GetPrice();
        await _context.SaveChangesAsync();
        return new Product(existingProduct.Id, existingProduct.Name, existingProduct.Price);
    }
}