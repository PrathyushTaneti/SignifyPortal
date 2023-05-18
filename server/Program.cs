global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using Signify.Models;
global using server.Data;
global using Microsoft.Extensions.DependencyInjection;
global using server.DTOClasses;
global using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using server.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAutoMapper(typeof(Program).Assembly)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

builder.Services
    .AddAuthenticationDP()
    .AddDbContextUtil(builder.Configuration)
    .AddCorsUtil();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("EnableCORS");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
