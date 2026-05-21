using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Data;
using BibliotecaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseInMemoryDatabase("BibliotecaDB"));

builder.Services.AddScoped<ILibroRepository, LibroRepository>();

builder.WebHost.UseUrls("http://+:8080");

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

