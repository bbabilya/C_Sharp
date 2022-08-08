var builder = WebApplication.CreateBuilder(args);
//variable is instance of webapp class.
builder.Services.AddControllersWithViews();
//MVC line
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
var app = builder.Build();
app.UseStaticFiles();
// static for css
app.UseRouting();
//use for routing to pages
app.UseAuthorization();
//authorizes a user to access secure resources
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//define pattern for approutes
app.UseSession();
app.Run();