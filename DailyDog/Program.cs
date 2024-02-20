using DailyDog.Components;
using DailyDog.Persistence;
using DailyDog.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<DapperDbConnection>();
builder.Services.AddSingleton<HouseholdRepository>();
builder.Services.AddSingleton<DogOwnerRepository>();
builder.Services.AddSingleton<DogRepository>();
builder.Services.AddSingleton<ActivityRepository>();
builder.Services.AddSingleton<LogRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
