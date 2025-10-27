using Microsoft.EntityFrameworkCore;
using SorveteriaApp.Application.Interfaces;
using SorveteriaApp.Application.Services;
using SorveteriaApp.Domain.Interfaces;
using SorveteriaApp.Infrastructure.Data;
using SorveteriaApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SorveteriaApp.Infrastructure")
    ));

// Injeção de Dependência
builder.Services.AddScoped<ISaborRepository, SaborRepository>();
builder.Services.AddScoped<ISaborService, SaborService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Sabores}/{action=Index}/{id?}");

app.Run();