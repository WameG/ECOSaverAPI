using ECOSaver;
using ECOSaver.Contexts;
using ECOSaver.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string policyName = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
    options.AddPolicy(name: "OnlyGET",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .WithMethods("GET")
                                  .AllowAnyHeader();
                              });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

bool useSql = true;

if (useSql)
{
    var optionaBuilder = new DbContextOptionsBuilder<WeatherContext>();
    optionaBuilder.UseSqlServer(Secret.ConnectionString);
    WeatherContext context = new WeatherContext(optionaBuilder.Options);
    builder.Services.AddSingleton<IWeatherRepository>(new WeatherRepositoryDB(context));
}
else
{
    builder.Services.AddSingleton<WeatherRepository>(new WeatherRepository());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
