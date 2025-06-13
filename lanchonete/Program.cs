using lanchonete.configuration;
using lanchonete.interfaces;
using lanchonete.repository;
using lanchonete.service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.WebHost.UseUrls("http://localhost:8080");

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdditionalRepository, AdditionalRepository>();
builder.Services.AddScoped<IItemRepository,  ItemRepository>();
builder.Services.AddScoped<IOrderRepository,  OrderRepository>();

builder.Services.AddScoped<AdditionalService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();