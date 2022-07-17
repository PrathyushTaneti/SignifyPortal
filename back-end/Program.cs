using SignifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SignifyAPI.Services.ServiceInterfaces;
using SignifyAPI.Services.ServiceClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SignifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ??
    throw new InvalidOperationException("Connection string 'SignifyDbContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var container = new Container();
builder.Services.AddSimpleInjector(container, options =>
 {
     options.AddAspNetCore().AddControllerActivation();
 });

container.Register<IStudentDetailService, StudentDetailService>();
container.Register<IEmployeeDetailService, EmployeeDetailService>();
container.Register<IActiveMeetingsService, ActiveMeetingsService>();
container.Register<IActiveProgramsService, ActiveProgramsService>();
container.Register<IPerformanceService, PerformanceService>();
container.Register<IAdminDetailsService, AdminDetailsService>();
container.Register<IAttendanceTrackerService, AttendanceTrackerService>();



var app = builder.Build();

app.Services.UseSimpleInjector(container);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()) ;

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
