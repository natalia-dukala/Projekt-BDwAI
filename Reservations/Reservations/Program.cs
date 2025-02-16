using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reservations.Controllers;
using Reservations.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Dodanie usług do kontenera
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Konfiguracja połączenia z bazą danych
builder.Services.AddDbContext<ReservationsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Konfiguracja Identity (z ról)
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ReservationsDbContext>()
    .AddRoles<IdentityRole>()  // Dodanie ról
    .AddDefaultTokenProviders();

// Zarejestrowanie NullEmailSender (nie wysyła emaili)
builder.Services.AddSingleton<IEmailSender, NullEmailSender>();

var app = builder.Build();

// Seedowanie danych
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ReservationsDbContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Seedowanie danych
    SeedDatabase(dbContext);
    await SeedUsersAndRolesAsync(userManager, roleManager);
}

// Konfiguracja potoku HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// SEEDOWANIE DANYCH
void SeedDatabase(ReservationsDbContext dbContext)
{
    if (!dbContext.Categories.Any())
    {
        var categories = new List<Category>
        {
            new() { Name = "Category 1" },
            new() { Name = "Category 2" },
            new() { Name = "Category 3" }
        };

        dbContext.Categories.AddRange(categories);
        dbContext.SaveChanges();
    }

    if (!dbContext.Hotels.Any())
    {
        var categories = dbContext.Categories.ToList();

        var hotels = new List<Hotel>
        {
            new() { Name = "Hotel 1", Street = "Street 1", City = "City 1", Country = "Country 1", CategoryId = categories[0].Id },
            new() { Name = "Hotel 2", Street = "Street 2", City = "City 2", Country = "Country 2", CategoryId = categories[1].Id },
            new() { Name = "Hotel 3", Street = "Street 3", City = "City 3", Country = "Country 3", CategoryId = categories[2].Id }
        };

        dbContext.Hotels.AddRange(hotels);
        dbContext.SaveChanges();

        foreach (var hotel in dbContext.Hotels.ToList())
        {
            var rooms = new List<Room>
            {
                new() { RoomNumber = 101, Size = "Small", IsRented = false, HotelId = hotel.Id },
                new() { RoomNumber = 102, Size = "Medium", IsRented = false, HotelId = hotel.Id },
                new() { RoomNumber = 103, Size = "Large", IsRented = false, HotelId = hotel.Id }
            };

            dbContext.Rooms.AddRange(rooms);
        }

        dbContext.SaveChanges();
    }
}

// SEEDOWANIE UŻYTKOWNIKÓW I RÓL
async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
{
    string adminRole = "Admin";
    string userRole = "User";

    // Tworzenie ról, jeśli nie istnieją
    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    }

    if (!await roleManager.RoleExistsAsync(userRole))
    {
        await roleManager.CreateAsync(new IdentityRole(userRole));
    }

    // Tworzenie admina
    if (await userManager.FindByEmailAsync("admin@example.com") == null)
    {
        var adminUser = new User
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            FirstName = "John",
            LastName = "Doe",
            EmailConfirmed = true
        };

        await userManager.CreateAsync(adminUser, "Admin123!");
        await userManager.AddToRoleAsync(adminUser, adminRole);
    }

    // Tworzenie zwykłego usera
    if (await userManager.FindByEmailAsync("user@example.com") == null)
    {
        var normalUser = new User
        {
            UserName = "user@example.com",
            Email = "user@example.com",
            FirstName = "Jane",
            LastName = "Kovalsky",
            EmailConfirmed = true
        };

        await userManager.CreateAsync(normalUser, "User123!");
        await userManager.AddToRoleAsync(normalUser, userRole);
    }
}

// IMPLEMENTACJA NullEmailSender
public class NullEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        // Nie wysyła żadnych maili - zwraca zakończoną operację
        return Task.CompletedTask;
    }
}
