using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_MDP_Web.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Proiect_MDP_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MDP_WebContext") ?? throw new InvalidOperationException("Connection string 'Proiect_MDP_WebContext' not found.")));

builder.Services.AddDbContext<MagazinSportivIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MDP_WebContext") ?? throw new InvalidOperationException("Connection string 'Proiect_MDP_WebContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MagazinSportivIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
