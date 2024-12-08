using GestionVols.Models;
using GestionVols.Models.Repos;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAvionRepos, AvionRepos>();
builder.Services.AddScoped<IReservationRepos, ReservationRepos>();
builder.Services.AddScoped<IPassagerRepos, PassagerRepos>();
builder.Services.AddScoped<IAeroportRepos, AeroportRepos>();
builder.Services.AddScoped<IVolRepos, VolRepos>(); 



var cnx = builder.Configuration.GetConnectionString("dbConn");
builder.Services.AddDbContext<VolDbContext>(
    options => options.UseSqlServer(cnx)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
