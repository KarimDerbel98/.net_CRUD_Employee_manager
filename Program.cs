using ExamTP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews(); 
builder.Services.AddDbContext<ManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManagementCS")));

var app = builder.Build();
//DI FOR DBContext
//builder.Services.AddDbContext<ManagementDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("ManagementCS")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Management}/{action=Index}/{id?}");

app.Run();
