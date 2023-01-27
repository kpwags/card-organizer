using CardOrganizer.Configuration;
using CardOrganizer.Database;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var cardOrganizerConfiguration = new CardOrganizerConfiguration();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Build configuration
var baseDirectory = Directory.GetParent(AppContext.BaseDirectory);
var environment = builder.Environment;

if (baseDirectory is null)
{
    throw new Exception("Unable to read base directory");
}

var configuration = new ConfigurationBuilder()
    .SetBasePath(baseDirectory.FullName)
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", false)
    .Build();

configuration.Bind(cardOrganizerConfiguration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        configuration.GetConnectionString("Main")
    );
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
