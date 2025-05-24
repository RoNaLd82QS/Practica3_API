using Microsoft.EntityFrameworkCore;
using API_PRACTICA3_MVC.Datos;
using API_PRACTICA3_MVC.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Base de datos SQLite
builder.Services.AddDbContext<FeedbackDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servicio externo JSONPlaceholder
builder.Services.AddHttpClient<ServicioPostal>();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Noticias}/{action=Indice}/{id?}");

app.Run();
