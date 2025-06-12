using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlantCare.Application.Mapping;
using PlantCare.Application.Plants.Interfaces;
using PlantCare.Application.Plants.Services;
using PlantCare.Application.Plants.Validators;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Application.Users.Services;
using PlantCare.Application.Users.Validators;
using PlantCare.Domain.Repositories;
using PlantCare.Infra.Data;
using PlantCare.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PlantCare API",
        Description = "An API for managing plant care information"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", 
        policy => policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddScoped<CreateUserRequestValidator>();
builder.Services.AddScoped<UpdateUserRequestValidator>();

builder.Services.AddScoped<CreatePlantRequestValidator>();
builder.Services.AddScoped<UpdatePlantRequestValidator>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPlantsService, PlantsService>();
builder.Services.AddScoped<IPlantsRepository, PlantsRepository>();

builder.Services.AddDbContext<PlantCareDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseCors("AllowReactApp");
app.UseRouting();  
app.UseAuthorization(); // If you're using authorization  
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PlantCareDbContext>();

    if (!await dbContext.Database.CanConnectAsync())
    {
        throw new NotImplementedException("Can't connect to database");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI();
}

await app.RunAsync();


