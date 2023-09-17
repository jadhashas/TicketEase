
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;
using TicketEase.Data.Cart;
using TicketEase.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration 

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Services configuration
builder.Services.AddScoped<IActorsService,ActorsService>();
builder.Services.AddScoped<IProducersService,ProducersService>();
builder.Services.AddScoped<ICinemasService,CinemasService>();
builder.Services.AddScoped<IMoviesService,MoviesService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed DB :  
AppDbInitializer.Seed(app);

app.Run();


