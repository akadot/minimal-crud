using Microsoft.EntityFrameworkCore;
using MinimalApi.DTOS;
using MinimalApi.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MinmalDbContext>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@test.com" && loginDTO.Senha == "123456"){
        return Results.Ok("Login executado com sucesso!");
    }else{
        return Results.Unauthorized();
    }
});

app.Run();
