using Microsoft.EntityFrameworkCore;
using System;
using WebApiWayni;
using WebApiWayni.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("WayniDB");

builder.Services.AddDbContext<WayniContext>(options =>
    options.UseSqlServer(
        connectionString, 
        sqlOptions => sqlOptions.EnableRetryOnFailure())
    , ServiceLifetime.Scoped
    );

builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
