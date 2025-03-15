using Application.Domain.Entity;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IntegratedTests.Features
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public async Task Test_Get_By_IdAsync()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductContext>().UseSqlite(connection).Options;


            using (var context = new ProductContext(options))
            {
                context.Database.EnsureCreated();
            }

            var repository = new ProductRepository(new ProductContext(options));
            await repository.CreateAsync(new Product("1", "Product 1", 100));
            var product = await repository.FindByIdAsync("1");

            Assert.That(product, Is.Not.Null);
            Assert.That("Product 1", Is.EqualTo(product?.GetName()));
        }

        [Test]
        public async Task Test_Update_Async()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductContext>().UseSqlite(connection).Options;

            using (var context = new ProductContext(options))
            {
                context.Database.EnsureCreated();
            }

            var repository = new ProductRepository(new ProductContext(options));

            await repository.CreateAsync(new Product("1", "Product 1", 100));

            var product = await repository.FindByIdAsync("1");
            product?.ChangeName("Product 2");
            var updatedProduct = await repository.UpdateAsync(product);

            Assert.That(updatedProduct, Is.Not.Null);
            Assert.That("Product 2", Is.EqualTo(updatedProduct?.GetName()));
        }

        [Test]
        public async Task Test_Get_All_Async()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductContext>().UseSqlite(connection).Options;

            using (var context = new ProductContext(options))
            {
                context.Database.EnsureCreated();
            }

            var repository = new ProductRepository(new ProductContext(options));

            await repository.CreateAsync(new Product("1", "Product 1", 100));
            await repository.CreateAsync(new Product("2", "Product 2", 200));

            var products = await repository.FindAllAsync();

            Assert.That(products, Is.Not.Null);
            Assert.That(2, Is.EqualTo(products.Count));
        }

        [Test]
        public async Task Test_Delete_By_Id_Async()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductContext>().UseSqlite(connection).Options;

            using (var context = new ProductContext(options))
            {
                context.Database.EnsureCreated();
            }

            var repository = new ProductRepository(new ProductContext(options));

            await repository.CreateAsync(new Product("1", "Product 1", 100));

            var product = await repository.FindByIdAsync("1");

            Assert.That(product, Is.Not.Null);
            Assert.That("Product 1", Is.EqualTo(product?.GetName()));

            await repository.DeleteAsync("1");

            var productDeleteted = await repository.FindByIdAsync("1");

            Assert.That(productDeleteted, Is.Null);
        }
    }
}