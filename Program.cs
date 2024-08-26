using MinimalApi.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Olá, Mundo!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "12345")
        return Results.Ok("Login com Sucesso");
    
    else
        return Results.Unauthorized();
});



app.Run();
