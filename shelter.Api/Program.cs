using Microsoft.EntityFrameworkCore;
using shelter.DataAccess;
using shelter.Application;
using shelter.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using shelter.DataAccess.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(option => option.Filters.Add<ErrorHandingFillterAttribute>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddDbContext<ShelterDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ShelterDbContext)));
    });

var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
