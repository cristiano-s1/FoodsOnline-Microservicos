using FoodsOnline.API.Context;
using FoodsOnline.API.Services;
using FoodsOnline.API.Repositories;
using Microsoft.EntityFrameworkCore;
using FoodsOnline.API.Services.Contracts;
using FoodsOnline.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region CONTROLLERS
builder.Services.AddControllers();
#endregion

#region SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region DATA BASE
var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(stringConnection));
#endregion

#region AUTO MAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region INJECTION DEPENDENCY
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
