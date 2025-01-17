using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Services;
using MinimalApi.DTOS;
using MinimalApi.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();

builder.Services.AddDbContext<MinmalDbContext>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) => {
    if(administratorService.Login(loginDTO) != null){
        return Results.Ok("Login com sucesso!");
    }else{
        return Results.Unauthorized();
    }
});

app.Run();
