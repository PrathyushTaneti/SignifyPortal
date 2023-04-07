using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class AdminEndpoints
{
    public static void MapAdminEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Admin").WithTags(nameof(Admin));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Admin.ToListAsync();
        })
        .WithName("GetAllAdmins")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Admin>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Admin.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Admin model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAdminById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Admin admin, SignifyContext db) =>
        {
            var affected = await db.Admin
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, admin.Id)
                  .SetProperty(m => m.EmailAddress, admin.EmailAddress)
                  .SetProperty(m => m.UserName, admin.UserName)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAdmin")
        .WithOpenApi();

        group.MapPost("/", async (Admin admin, SignifyContext db) =>
        {
            db.Admin.Add(admin);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Admin/{admin.Id}",admin);
        })
        .WithName("CreateAdmin")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Admin
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAdmin")
        .WithOpenApi();
    }
}
