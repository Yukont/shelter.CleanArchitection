using Microsoft.EntityFrameworkCore;
using shelter.DataAccess.Context;
using shelter.Domain.Abstractions;
using shelter.Application.Services;
using shelter.DataAccess.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShelterDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ShelterDbContext)));
    });

builder.Services.AddScoped<IAnimalStatusService, AnimalStatusService>();
builder.Services.AddScoped<IAnimalStatusesRepository, AnimalStatusesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
