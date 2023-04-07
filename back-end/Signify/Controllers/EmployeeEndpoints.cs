using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Employee").WithTags(nameof(Employee));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Employee.ToListAsync();
        })
        .WithName("GetAllEmployees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Employee>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Employee.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Employee model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEmployeeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Employee employee, SignifyContext db) =>
        {
            var affected = await db.Employee
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, employee.Id)
                  .SetProperty(m => m.FirstName, employee.FirstName)
                  .SetProperty(m => m.LastName, employee.LastName)
                  .SetProperty(m => m.Gender, employee.Gender)
                  .SetProperty(m => m.MobileNumber, employee.MobileNumber)
                  .SetProperty(m => m.Department, employee.Department)
                  .SetProperty(m => m.EmailAddress, employee.EmailAddress)
                  .SetProperty(m => m.Subject, employee.Subject)
                  .SetProperty(m => m.ProfilePicture, employee.ProfilePicture)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateEmployee")
        .WithOpenApi();

        group.MapPost("/", async (Employee employee, SignifyContext db) =>
        {
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Employee/{employee.Id}",employee);
        })
        .WithName("CreateEmployee")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Employee
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEmployee")
        .WithOpenApi();
    }
}
