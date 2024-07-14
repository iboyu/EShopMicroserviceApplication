using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Interfaces.Repositories;
using OrderAPI.ApplicationCore.Interfaces.Services;
using OrderAPI.Infrastructure.Data;
using OrderAPI.Infrastructure.Repositories;
using OrderAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderdetailService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
//builder.Services.AddScoped<IRabitMQProducerConsumer, RabitMQProducerConsumer>();
//builder.Services.AddScoped<IDocumentService, DocumentService>();

// Repository
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

// DbContext
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("OrderDB"));
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
