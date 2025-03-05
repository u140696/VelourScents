using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Velour_Scents.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ✅ Enable Identity & Roles
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
})
.AddRoles<IdentityRole>() // Enables role support
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ Ensures static files (CSS, JS, images) are served

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// ✅ Create Roles and Users on Startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    try
    {
        await SeedRolesAndUsers(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding users: {ex.Message}");
    }
}

app.Run();

// ✅ Method to Seed Roles & Users
async Task SeedRolesAndUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // ✅ Create Roles if not exists
    if (!await roleManager.RoleExistsAsync("Administrator"))
        await roleManager.CreateAsync(new IdentityRole("Administrator"));

    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new IdentityRole("User"));

    // ✅ Create Admin (Urvish)
    string adminEmail = "urvish@velourscents.com";
    string adminPassword = "Urvish@1406";
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(admin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Administrator");
            Console.WriteLine("✅ Admin User Created: Urvish");
        }
        else
        {
            Console.WriteLine($"❌ Error Creating Admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    // ✅ Create User 1 (Vidhi)
    string user1Email = "vidhi@velourscents.com";
    string user1Password = "Vidhi@06";
    if (await userManager.FindByEmailAsync(user1Email) == null)
    {
        var user1 = new IdentityUser { UserName = user1Email, Email = user1Email };
        var result = await userManager.CreateAsync(user1, user1Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user1, "User");
            Console.WriteLine("✅ User 1 Created: Vidhi");
        }
        else
        {
            Console.WriteLine($"❌ Error Creating User 1: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    // ✅ Create User 2 (Manish)
    string user2Email = "manish@velourscents.com";
    string user2Password = "Manish@14";
    if (await userManager.FindByEmailAsync(user2Email) == null)
    {
        var user2 = new IdentityUser { UserName = user2Email, Email = user2Email };
        var result = await userManager.CreateAsync(user2, user2Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "User");
            Console.WriteLine("✅ User 2 Created: Manish");
        }
        else
        {
            Console.WriteLine($"❌ Error Creating User 2: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
