using FoodsOnline.Web.Services;
using FoodsOnline.Web.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


#region CONTROLLER
builder.Services.AddControllersWithViews();
#endregion

#region SERVIÇO
builder.Services.AddHttpClient("UrlApi", c => 
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:FoodsOnlineApi"]);
});
#endregion

#region IDENPENDENCY INJECT
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
