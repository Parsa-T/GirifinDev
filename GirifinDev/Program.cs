using GirifinDev.Application.Interface;
using GirifinDev.Infra.Data.Context;
using GirifinDev.Infra.IoC;
using GirifinDev.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region My Context
builder.Services.AddDbContext<GirifinDevContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GirifinDevContext"));
});
#endregion

#region Services
RegisterServices(builder.Services);
static void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}
builder.Services.AddScoped<IProjectQueriServices, ProjectQueriServices>();
builder.Services.AddScoped<IUserTeamRepository, UserTeamRepository>();
#endregion

#region Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Loguot";
        options.ExpireTimeSpan = TimeSpan.FromDays(10);
    });
#endregion

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
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Login");
        }
    }
    await next.Invoke();
});
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();