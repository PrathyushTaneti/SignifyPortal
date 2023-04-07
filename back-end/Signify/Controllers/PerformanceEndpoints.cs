using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class PerformanceEndpoints
{
    public static void MapPerformanceEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Performance").WithTags(nameof(Performance));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Performance.ToListAsync();
        })
        .WithName("GetAllPerformances")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Performance>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Performance.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Performance model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPerformanceById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Performance performance, SignifyContext db) =>
        {
            var affected = await db.Performance
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, performance.Id)
                  .SetProperty(m => m.RollNumber, performance.RollNumber)
                  .SetProperty(m => m.PerformanceOfStudent, performance.PerformanceOfStudent)
                  .SetProperty(m => m.QuizName, performance.QuizName)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePerformance")
        .WithOpenApi();

        group.MapPost("/", async (Performance performance, SignifyContext db) =>
        {
            db.Performance.Add(performance);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Performance/{performance.Id}",performance);
        })
        .WithName("CreatePerformance")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Performance
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePerformance")
        .WithOpenApi();
    }
}
