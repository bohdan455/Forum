using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VerySimpleForum.DataBase;
using VerySimpleForum.DataBase.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//add DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

//Identity Setting
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 7;

    options.Lockout.MaxFailedAccessAttempts = 7;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);

});

//logging
builder.Host.UseSerilog((context,config) =>
{
    config.WriteTo.Console();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePagesWithRedirects("/error/");

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
