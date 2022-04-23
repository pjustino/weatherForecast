using System.Text.Json.Serialization;
using weather.services;
using weather.services.Validators;
using weather.services.mappers;
using WeatherForecast;
using Domain.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add my dependencies
builder.Services.AddTransient<ITemperatureValidator, TemperatureValidator>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddSingleton<ITemperatureForecastMapper, TemperatureForecastMapper>();
builder.Services.AddSingleton<ITemperatureConverter, TemperatureConverter>();

builder.Services.AddControllers().AddJsonOptions(
    o => {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
