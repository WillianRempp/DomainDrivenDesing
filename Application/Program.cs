using Application.Domain.Checkout.Repository;
using Application.Domain.Customer.Event;
using Application.Domain.Customer.Event.Handler;
using Application.Domain.Customer.Repository;
using Application.Domain.Product.Event;
using Application.Domain.Product.Event.Handler;
using Application.Domain.Product.Repository;
using Application.Domain.shared.Event;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite("Data Source=Database.db")
);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();

builder.Services.AddSingleton<IEventDispatcher, EventDispatcher>();
builder.Services.AddSingleton<IEventHandler, SendEmailWhenProductIsCreatedHandler>();
builder.Services.AddSingleton<IEventHandler, LogWhenCustomerIsCreatedHandler>();
builder.Services.AddSingleton<IEventHandler, LogWhenCustomerIsUpdatedHandler>();

var app = builder.Build();

// Após criar o app, você pode registrar o handler
var dispatcher = app.Services.GetRequiredService<IEventDispatcher>();
var handler = app.Services.GetRequiredService<IEventHandler>();

// Faz o registro do handler com o nome do evento
await dispatcher.Register(nameof(ProductCreatedEvent), handler);
await dispatcher.Register(nameof(CustomerCreatedEvent), handler);
await dispatcher.Register(nameof(CustomerUpdatedEvent), handler);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();