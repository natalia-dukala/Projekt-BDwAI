using Reservations.Controllers;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReservationsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedDatabase(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

void SeedDatabase(IServiceProvider services)
{
    using var context = services.GetRequiredService<ReservationsDbContext>();
    context.Database.Migrate();

    if (!context.Categories.Any())
    {
        context.Categories.Add(new Category { Name = "Test 1" });
        context.Categories.Add(new Category { Name = "Test 2" });
        context.Categories.Add(new Category { Name = "Test 3" });

        context.SaveChanges();
    }
}