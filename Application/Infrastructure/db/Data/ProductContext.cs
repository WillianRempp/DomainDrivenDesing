using Application.Infrastructure.db.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.db.Data
{
    public class ProductContext : DbContext
    {
        private readonly string connectionString;

        public ProductContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> ProductModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}