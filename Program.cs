using Microsoft.EntityFrameworkCore;
using PriorityDashboard.Data;

var builder = WebApplication.CreateBuilder(args);

// सेवices
builder.Services.AddRazorPages();

// THIS LINE IS CRITICAL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TasksDb"));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();