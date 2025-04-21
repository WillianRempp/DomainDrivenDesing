using Application.Domain.Product.Entity;
using Application.Domain.Product.Factory;
using Application.Domain.Product.Repository;
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

    public async Task CreateAsync(IProduct entity)
    {
        await _context.ProductModel.AddAsync(
            new ProductModel
            {
                Id = entity.GetId(),
                Name = entity.GetName(),
                Price = entity.GetPrice()
            });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var productModel = await _context.ProductModel.FirstOrDefaultAsync(x => x.Id == id);
        if (productModel != null)
        {
            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<IProduct>> FindAllAsync()
    {
        var products = _context.ProductModel.Select(
            x => ProductFactory.Create("a", x.Id, x.Name, x.Price)).ToList();
        return Task.FromResult(products);
    }


    public async Task<IProduct?> FindByIdAsync(string id)
    {
        var productModel = await _context.ProductModel.FirstOrDefaultAsync(x => x.Id == id);
        if (productModel == null)
        {
            return null;
        }

        return ProductFactory.Create("a" ,productModel.Id, productModel.Name, productModel.Price);
    }


    public async Task<IProduct?> UpdateAsync(IProduct entity)
    {
        var existingProduct = await _context.ProductModel.FirstOrDefaultAsync(x => x.Id == entity.GetId());
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = entity.GetName();
        existingProduct.Price = entity.GetPrice();
        await _context.SaveChangesAsync();
        return ProductFactory.Create("a" ,existingProduct.Id, existingProduct.Name, existingProduct.Price);
    }
}