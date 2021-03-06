using RaceGameUI_BlazorPractice.Dal;
using RaceGameUI_BlazorPractice.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// everywhere where you use this interface, use a single instance (singleton) of the second thing
builder.Services.AddSingleton<IBettorRepository, BettorRepository>();
builder.Services.AddSingleton<IGreyHoundRepository, GreyHoundRepository>();

// services
builder.Services.AddSingleton<IBettorService, BettorService>();
builder.Services.AddSingleton<IGreyHoundService, GreyHoundService>();
builder.Services.AddSingleton<IBetService, BetService>();
builder.Services.AddSingleton<IRaceTrackService, RaceTrackService>();

builder.Services.AddServerSideBlazor();

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
