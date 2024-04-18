using Contacts.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Api.Endpointns;

public static class PersonsEndPoints
{
    const string GetUserEndPoint = "GetPerson";


    static readonly List<UsersSummaryDtos> persons = [

        new (
    1,
    "Emirhan",
    "Albayrak",

    "EA@gmail.com",

    "5537622553"
    ),
     new (
    2,
    "Doğukan",

    "Albayrak",

    "DA@gmail.com",

    "5537892553"
    ),

     new (
    3,
    "Fatma",
    "Albayrak",

    "fA@gmail.com",

    "5457622553"
    ),

     new (
    4,
    "Erol",
    "Albayrak",

    "EA@gmail.com",

    "5537622525"
    )

    ];

    public static RouteGroupBuilder MapPersonsEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("persons");
        //GET USERT /GET
        app.MapGet("persons", async (DirectoryContex dbContex) => await dbContex.people.Include(person => person.PhoneNumber)

        .Select(person => person.ToUsersSummaryDto()).AsNoTracking().ToListAsync());


        // GET PERSON/1
        group.MapGet("/{id}", async (int id, DirectoryContex dbContext) =>
        {
            Person? p = await dbContext.people.FindAsync(id);
            return p is null ? Results.NotFound() : Results.Ok(p.ToUsersDetailsDto());
        }).WithName(GetUserEndPoint);

        //Post/games
        group.MapPost("/", async (CreatePersonDtos newPerson, DirectoryContex dbContex) =>
        {
            if (string.IsNullOrEmpty(newPerson.Name))
            {
                return Results.BadRequest("Name is Required");
            }
            Person person = new()
            {
                Name = newPerson.Name,
                SurName = newPerson.Surname,
                mail = newPerson.mail,
                PhoneNumber = dbContex.numbers.Find(newPerson.phoneNumberId),
                phoneNumberId = newPerson.phoneNumberId,
            };

            dbContex.Add(person);
            await dbContex.SaveChangesAsync();
            Person p = newPerson.ToEntity();
            p.PhoneNumber = dbContex.numbers.Find(newPerson.phoneNumberId);
            return Results.CreatedAtRoute(GetUserEndPoint, new { id = person.Id }, p.ToUsersDetailsDto());
        });

        // Put persons/
        group.MapPut("/{id}", async (int id, UpdatePersonDtos updatePerson, DirectoryContex dbContex) =>
        {
            var existPerson = await dbContex.people.FindAsync(id);
            if (existPerson is null)
            {
                return Results.NotFound();
            }
            dbContex.Entry(existPerson).CurrentValues.SetValues(updatePerson.ToEntity(id));
            await dbContex.SaveChangesAsync();
            return Results.NoContent();
        });

        //Delete 
        group.MapDelete("/{id}", async (int id, DirectoryContex dbContex) =>
        {
            await dbContex.people.Where(p => p.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
