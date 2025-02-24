using Microsoft.EntityFrameworkCore;
using SaleAPI.Infrastructure.Data;
using SaleAPI.Infrastructure.Repositories;
using SaleAPI.Application.Service;
using SaleAPI.Domain.Interfaces;
using SaleAPI.Application.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar os serviço
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<SalesProductsService>();

// Registrar os repositório
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ISalesProductsRepository, SalesProductsRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SalesAPI",
        Version = "v1",
        Description = "API para gerenciamento de vendas",
        Contact = new OpenApiContact
        {
            Name = "Vinicius Lopes",
            Email = "vlopes.ti@gmail.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SalesAPI v1");
        c.RoutePrefix = string.Empty; // Deixa o Swagger acessível na raiz da URL
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

