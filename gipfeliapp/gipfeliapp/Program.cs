using gipfeliapp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-6.0#localization-middleware
//MS Learn: The localization middleware must be configured before any middleware which might check the request culture (for example, app.UseMvcWithDefaultRoute())
string[] supportedCultures = new[] { "de-DE", "de-CH" };
app.UseRequestLocalization(new RequestLocalizationOptions() //Default: Query > Cookie > Accept-Language Header
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

app.Run();
