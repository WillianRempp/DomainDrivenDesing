using Application.Domain.Checkout.Entity;
using Application.Domain.Checkout.Factory;
using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;
using Application.Domain.Product.Factory;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IntegratedTests.Features;

[TestFixture]
public class OrderTest
{
    private static async Task<CustomerRepository> CreateCustomerRepository()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        var customerRepository = new CustomerRepository(new Context(options));
        return customerRepository;
    }

    private static async Task<ProductRepository> CreateProductRepository()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        return new ProductRepository(new Context(options));
    }

    private static async Task<OrderRepository> CreateOrderRepository()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        return new OrderRepository(new Context(options));
    }

    [Test]
    public async Task Test_Create_Order_Async()
    {
        var customerRepository = await CreateCustomerRepository();
        var productRepository = await CreateProductRepository();
        var orderRepository = await CreateOrderRepository();

        var customer = CustomerFactory.CreateWithIdAndAddress("1", "Customer 1",
            new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        await customerRepository.CreateAsync(customer);

        var product = ProductFactory.Create("a", "1", "Product 1", 100);
        await productRepository.CreateAsync(product);

        var orderItem = new OrderItem("1", product.GetName(), product.GetPrice(), product.GetId(), 1);

        var order = OrderFactory.Create("1", customer.GetId(), new List<OrderItem> { orderItem });
        await orderRepository.CreateOrderAsync(order, customer);

        var orderOnDatabase = await orderRepository.FindByIdAsync(order.GetId());

        Assert.That(orderOnDatabase, Is.Not.Null);
        Assert.That("1", Is.EqualTo(orderOnDatabase?.GetCostumerId()));
    }
}