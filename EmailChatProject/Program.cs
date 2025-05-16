
using EmailChatProject.Entities;
using EmailChatProject.Models;
using EmailChatProject.Context;

using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextEmail>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ContextEmail>().AddErrorDescriber<CustomIdentityValidator>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();