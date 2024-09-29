var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// //Aggregate - ID
// var customer = new Customer("1", "Willian");
// var address = new Address("Rua dos bobos", "0", "00000-000", "Jundiai");
// customer.AddAddress(address);
// customer.Activate();

// //Aggregate - Object
// var item1 = new OrderItem("1", "Item 1", 10);
// var item2 = new OrderItem("2", "Item 2", 20);
// var item3 = new OrderItem("3", "Item 3", 30);
// var order = new Order("1", "1", new List<OrderItem> { item1, item2, item3 });



// Console.WriteLine(customer);

app.UseHttpsRedirection();

app.Run();
