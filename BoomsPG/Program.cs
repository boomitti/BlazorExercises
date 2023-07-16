using Append.Blazor.Printing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BoomsPG.Data;

// MudBlazor and Extension
using MudBlazor.Services;
using MudExtensions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Print service
builder.Services.AddScoped<IPrintingService, PrintingService>();

// HTTP service
builder.Services.AddHttpClient();

// MudBlazor
builder.Services.AddMudServices();
builder.Services.AddMudExtensions();

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