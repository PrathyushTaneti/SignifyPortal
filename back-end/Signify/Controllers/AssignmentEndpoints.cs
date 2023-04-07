using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class AssignmentEndpoints
{
    public static void MapAssignmentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Assignment").WithTags(nameof(Assignment));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Assignment.AsNoTracking().ToListAsync();
        })
        .WithName("GetAllAssignments").WithOpenApi();





        group.MapGet("/{id}", async Task<Results<Ok<Assignment>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Assignment.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Assignment model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAssignmentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Assignment assignment, SignifyContext db) =>
        {
            var affected = await db.Assignment
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, assignment.Id)
                  .SetProperty(m => m.ProgramLink, assignment.ProgramLink)
                  .SetProperty(m => m.ProgramName, assignment.ProgramName)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAssignment")
        .WithOpenApi();

        group.MapPost("/", async (Assignment assignment, SignifyContext db) =>
        {
            db.Assignment.Add(assignment);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Assignment/{assignment.Id}",assignment);
        })
        .WithName("CreateAssignment")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Assignment
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAssignment")
        .WithOpenApi();
    }
}
