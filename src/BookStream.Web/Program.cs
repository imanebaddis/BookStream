using BookStream.Application.Common;
using BookStream.Infrastructure.Common;
using BookStream.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configurazione Supabase
var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];
var options = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true
};

builder.Services.AddSingleton(provider =>
    new Client(supabaseUrl, supabaseKey, options));


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// ... altri servizi

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
// ... altre configurazioni
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Registra i servizi
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

// Registra i validator
builder.Services.AddValidatorsFromAssemblyContaining<CreateSubscriptionCommandValidator>();

// ... resto della configurazione

builder.Services.AddScoped<IBookService, BookService>();

app.Run();

