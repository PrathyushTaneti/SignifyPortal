using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Signify.Data;
using Signify.Controllers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SignifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SignifyContext") ?? throw new InvalidOperationException("Connection string 'SignifyContext' not found.")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.MapAdminEndpoints();

app.MapAssignmentEndpoints();


app.Run();
