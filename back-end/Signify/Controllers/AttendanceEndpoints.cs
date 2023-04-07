using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class AttendanceEndpoints
{
    public static void MapAttendanceEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Attendance").WithTags(nameof(Attendance));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Attendance.ToListAsync();
        })
        .WithName("GetAllAttendances")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Attendance>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Attendance.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Attendance model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAttendanceById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Attendance attendance, SignifyContext db) =>
        {
            var affected = await db.Attendance
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, attendance.Id)
                  .SetProperty(m => m.Date, attendance.Date)
                  .SetProperty(m => m.Identity, attendance.Identity)
                  .SetProperty(m => m.Designation, attendance.Designation)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAttendance")
        .WithOpenApi();

        group.MapPost("/", async (Attendance attendance, SignifyContext db) =>
        {
            db.Attendance.Add(attendance);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Attendance/{attendance.Id}",attendance);
        })
        .WithName("CreateAttendance")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Attendance
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAttendance")
        .WithOpenApi();
    }
}
