// Additional libraries
using Microsoft.EntityFrameworkCore;
using ProductsandCategories.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();  // add this line before calling the builder.Build() method

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

////// everything above ^^^^ build before builder.Build();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();