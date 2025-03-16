using Application.Infrastructure.db.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.db.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<AddressModel> AddressModel { get; set; }
    
    public DbSet<OrderModel> OrderModel { get; set; }
    public DbSet<CustomerModel> CustomerModel { get; set; }
    
    public DbSet<ProductModel> ProductModel { get; set; }
}