// Add using statements
using FinanceTracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure services
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Ajoutez les services de contrôleur avec vues
builder.Services.AddControllersWithViews(); // Cette ligne est nécessaire

// Ajoutez l'autorisation si vous en avez besoin
builder.Services.AddAuthorization(); 

// Build the app
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
