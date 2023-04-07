using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Student>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Student.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Student model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Student student, SignifyContext db) =>
        {
            var affected = await db.Student
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, student.Id)
                  .SetProperty(m => m.FirstName, student.FirstName)
                  .SetProperty(m => m.LastName, student.LastName)
                  .SetProperty(m => m.MobileNumber, student.MobileNumber)
                  .SetProperty(m => m.Gender, student.Gender)
                  .SetProperty(m => m.Course, student.Course)
                  .SetProperty(m => m.Department, student.Department)
                  .SetProperty(m => m.RollNumber, student.RollNumber)
                  .SetProperty(m => m.GuardianName, student.GuardianName)
                  .SetProperty(m => m.Address, student.Address)
                  .SetProperty(m => m.ProfilePicture, student.ProfilePicture)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (Student student, SignifyContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Student/{student.Id}",student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Student
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
