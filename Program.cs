using Microsoft.EntityFrameworkCore;
using StatusGridAPI.Data;
using StatusGridAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Cors
var localOrigin = "my-local-origin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: localOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGridConfigurationService, GridConfigurationService>();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(localOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
