using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.MVC.Data;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the IoC container.
//what does it means when the applicaiton starts ,grab me the connectionstring 
var conn = builder.Configuration.GetConnectionString("StudentAdminPortalDb");
//then use the connection string to initialize actual connection to the database that this(SchoolManagementDbContext) 
//DbContext is a model of here(conn) is the connection string that you should use.
builder.Services.AddDbContext<SchoolManagementDbContext>(opt => opt.UseSqlServer(conn));
 builder.Services.AddAuth0WebAppAuthentication(options => {
            options.Domain = builder.Configuration["Auth0:Domain"];
            options.ClientId = builder.Configuration["Auth0:ClientId"];
        });
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(c => {
    c.DurationInSeconds =5;
    c.IsDismissable=true;
    c.Position=NotyfPosition.TopRight;
});

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

app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
