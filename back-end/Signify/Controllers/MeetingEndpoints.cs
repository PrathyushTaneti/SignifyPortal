using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Signify.Data;
using Signify.Models;
namespace Signify.Controllers;

public static class MeetingEndpoints
{
    public static void MapMeetingEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Meeting").WithTags(nameof(Meeting));

        group.MapGet("/", async (SignifyContext db) =>
        {
            return await db.Meeting.ToListAsync();
        })
        .WithName("GetAllMeetings")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Meeting>, NotFound>> (int id, SignifyContext db) =>
        {
            return await db.Meeting.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Meeting model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMeetingById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Meeting meeting, SignifyContext db) =>
        {
            var affected = await db.Meeting
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, meeting.Id)
                  .SetProperty(m => m.JoinLink, meeting.JoinLink)
                  .SetProperty(m => m.Subject, meeting.Subject)
                  .SetProperty(m => m.StartTime, meeting.StartTime)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMeeting")
        .WithOpenApi();

        group.MapPost("/", async (Meeting meeting, SignifyContext db) =>
        {
            db.Meeting.Add(meeting);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Meeting/{meeting.Id}",meeting);
        })
        .WithName("CreateMeeting")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, SignifyContext db) =>
        {
            var affected = await db.Meeting
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMeeting")
        .WithOpenApi();
    }
}
