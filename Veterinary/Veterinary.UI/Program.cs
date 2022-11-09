using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Veterinary.UI.Data;
using Veterinary.UI.Interfaces;
using Veterinary.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Inyección de dependencias del UI
builder.Services.AddHttpClient<IClientServices, ClientServices>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["apiurl"]);
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
