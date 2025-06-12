using lanchonete.configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.Configure<MongodbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.WebHost.UseUrls("http://localhost:8080");

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();