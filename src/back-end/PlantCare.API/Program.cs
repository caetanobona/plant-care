using Microsoft.EntityFrameworkCore;
using PlantCare.Application.Context;
using PlantCare.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IPlantCareDbContext, PlantCareDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IPlantCareDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        Console.WriteLine("Database connection could not be established");
        // throw new NotImplementedException("Can't connect to database");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI();
}

app.Run();

