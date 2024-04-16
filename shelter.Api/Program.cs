using Microsoft.EntityFrameworkCore;
using shelter.DataAccess.Context;
using shelter.DataAccess;
using shelter.Application;
using shelter.Api.Middleware;
using shelter.Api.Fillters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using shelter.Api.Common.Error;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(option => option.Filters.Add<ErrorHandingFillterAttribute>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShelterDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ShelterDbContext)));
    });

builder.Services.AddApplication();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddSingleton<ProblemDetailsFactory, ShelterProblemDelailsFactory>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
