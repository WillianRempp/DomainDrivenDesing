using Application.Domain.Customer.Entity;
using Application.Domain.Customer.Factory;
using Application.Domain.Customer.ValueObject;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IntegratedTests.Features;

[TestFixture]
public class CustomerTest
{
    [Test]
    public async Task Test_Get_By_IdAsync()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        var repository = new CustomerRepository(new Context(options));
        
        var customer =CustomerFactory.CreateWithAddress( "Customer 1",new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer.AddRewardsPoints(10);
        await repository.CreateAsync(customer);

        Assert.That(customer, Is.Not.Null);
        Assert.That("Customer 1", Is.EqualTo(customer?.GetName()));
    }

    [Test]
    public async Task Test_Update_Async()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        var repository = new CustomerRepository(new Context(options));

        var customer =CustomerFactory.CreateWithIdAndAddress("1", "Customer 1",new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer.AddRewardsPoints(10);
        await repository.CreateAsync(customer);

        var customerOnDatabase = await repository.FindByIdAsync("1");
        customerOnDatabase?.ChangeName("Customer 2");
        var updatedCustomer = await repository.UpdateAsync(customerOnDatabase);

        Assert.That(updatedCustomer, Is.Not.Null);
        Assert.That("Customer 2", Is.EqualTo(updatedCustomer?.GetName()));
    }

    [Test]
    public async Task Test_Get_All_Async()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        var repository = new CustomerRepository(new Context(options));

        var customer =CustomerFactory.CreateWithAddress( "Customer 1",new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer.AddRewardsPoints(10);
        await repository.CreateAsync(customer);
        
        var customer2 =CustomerFactory.CreateWithAddress( "Customer 2",new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer2.AddRewardsPoints(10);
        await repository.CreateAsync(customer2);

        var customers = await repository.FindAllAsync();

        Assert.That(customers, Is.Not.Null);
        Assert.That(2, Is.EqualTo(customers.Count));
    }

    [Test]
    public async Task Test_Delete_By_Id_Async()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

        await using (var context = new Context(options))
        {
            await context.Database.EnsureCreatedAsync();
        }

        var repository = new CustomerRepository(new Context(options));
        var customer =CustomerFactory.CreateWithIdAndAddress("1", "Customer 1",new Address("Rua dos bobos", "0", "00000-000", "Jundiai"));
        customer.AddRewardsPoints(10);
        await repository.CreateAsync(customer);

        var customerOnDatabase = await repository.FindByIdAsync("1");

        Assert.That(customer, Is.Not.Null);
        Assert.That("Customer 1", Is.EqualTo(customerOnDatabase?.GetName()));

        await repository.DeleteAsync("1");

        var customerDeleted = await repository.FindByIdAsync("1");

        Assert.That(customerDeleted, Is.Null);
    }
}