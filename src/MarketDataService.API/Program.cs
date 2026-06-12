using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Application.Interfaces.Repositories;
using MarketDataService.Application.Interfaces.Services;
using MarketDataService.Application.Services;
using MarketDataService.Infrastructure.Persistence;
using MarketDataService.Infrastructure.Providers;
using MarketDataService.Infrastructure.Repositories;
using MarketDataService.Infrastructure.Settings;
using MarketDataService.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IMarketDataSyncService, MarketDataSyncService>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();

//Settings
builder.Services.Configure<BrapiSettings>(
    builder.Configuration.GetSection(BrapiSettings.SectionName));

//Providers
builder.Services.AddHttpClient<IMarketDataProvider, BrapiProvider>((sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<BrapiSettings>>().Value;

    client.BaseAddress = new Uri(settings.BaseUrl);
    
    client.DefaultRequestHeaders.Add("Authorization",$"{settings.ApiKey}");

    client.Timeout = TimeSpan.FromSeconds(30);
});

//Worker
builder.Services.AddHostedService<MarketDataSyncWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
