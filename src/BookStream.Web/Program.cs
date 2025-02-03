using BookStream.Application.Common;
using BookStream.Infrastructure.Common;
using BookStream.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using MediatR;
using FluentValidation;
using BookStore.Application.Handlers;
using BookStore.Application.Commands;
using BookStore.Application.Validators;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<BookStreamDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureServices(builder.Configuration);


// Add services to the container.
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}



// Configura i servizi per il container
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        // Legge ClientId e ClientSecret da una configurazione sicura
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
        options.CallbackPath = "/signin-google"; // Puoi personalizzare il percorso
    });

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Crea l'app
var app = builder.Build();

// Configura il middleware del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Valore predefinito HSTS di 30 giorni (per HTTPS)
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aggiungi l'autenticazione e autorizzazione al pipeline
app.UseAuthentication();
app.UseAuthorization();

// Configura il routing per i controller MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configura le mappature degli endpoint API controller se necessario
app.MapControllers();

// Avvia l'applicazione
app.Run();




var builder = WebApplication.CreateBuilder(args);

// Registrazione di MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProcessPaymentCommandHandler).Assembly));

// Registrazione dei validatori
builder.Services.AddValidatorsFromAssembly(typeof(ProcessPaymentCommandValidator).Assembly);

// Registrazione dei repository
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

var app = builder.Build();

app.Run();