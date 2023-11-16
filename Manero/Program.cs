using Manero.Contexts;
using Manero.Helpers.Repositories;
using Manero.Helpers.Services;
using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); 
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
//Services
builder.Services.AddScoped<SignUpService>();
builder.Services.AddScoped<SignInService>();
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<ProductDetailsService>();
builder.Services.AddScoped<ReviewService>();

//Repositories
builder.Services.AddScoped<SignUpRepo>();
builder.Services.AddScoped<ShoppingCartRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductDetailsRepo>();
builder.Services.AddScoped<CartItemRepository>();


//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;

})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
