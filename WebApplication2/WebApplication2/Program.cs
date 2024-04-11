using Microsoft.AspNetCore.Mvc;
using WebApplication2.DB;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
// GET /api/students
app.MapGet("/api/animals", () =>
{
    if (animalDB.Animals.Any())
    {
        return Results.Ok(animalDB.Animals);
    }
    return Results.NotFound("empty list");
    
});

// GET /api/students/1
app.MapGet("/api/animals/{id:int}", (int id) =>
{
    var student = animalDB.Animals.FirstOrDefault(st => st.Id == id);
    return student is null ? Results.NotFound() : Results.Ok(student);
});

// POST api/students
app.MapPost("/api/animals", ([FromBody] Animal student) =>
{
    if (animalDB.Animals.Any(a => a.Id == student.Id))
    {
        return Results.Conflict($"Animal with id {student.Id} already exists");
    }
    animalDB.Animals.Add(student);
    return Results.Created($"/api/animals/{student.Id}", student);
});

// PUT api/students/1
app.MapPut("/api/animals/{id:int}", (int id, [FromBody] Animal data) =>
{
    var student = animalDB.Animals.FirstOrDefault(st => st.Id == id);
    if (student is null) return Results.NotFound($"Animal with id {id} not found");
    
    
    if (!data.Name.Equals("string") && student.Name != data.Name)
        student.Name = data.Name;

    if (!data.Type.Equals("string") && student.Type != data.Type)
        student.Type = data.Type;

    if (data.Mass != 0 && student.Mass != data.Mass)
        student.Mass = data.Mass;

    if (!data.furColor.Equals("string") && student.furColor != data.furColor)
        student.furColor = data.furColor;
    
    return Results.Ok(student);
});

app.MapDelete("/api/animals/{id:int}", (int id) =>
{
    var student = animalDB.Animals.Where(st => st.Id == id);
    if (student == null)
    {
        return Results.NotFound($"Animal not found");
    }

    var students = animalDB.Animals.Where(a => a.Id != id);
    animalDB.Animals = students.ToList();
    return Results.Ok();
});

app.MapGet("/api/animals/{id:int}/amongus", (int id) =>
{
    var animal = animalDB.Animals.FirstOrDefault(a => a.Id == id);
    if (animal != null)
    {
        var appointments = amongusDB.amongusList.Where(a => a.Animal.Id == id);
        if (appointments == null)
        {
            return Results.NotFound($"Appointments {id} not found");
        }
    }
    else
    {
        return Results.NotFound($"Animal {id} not found");
    }

    return Results.Ok(amongusDB.amongusList);
});

app.MapPost("/api/animals/{id:int}/amongus", 
    (int id, [FromBody] amongus appointment) =>
    {
        var animal = animalDB.Animals.FirstOrDefault(a => a.Id == id);
        if (animal != null)
        {
            var appointments = amongusDB.amongusList.Where(a => a.Id == id);
            if (appointments.Any(a => a.Id == appointment.Id))
            {
                return Results.Conflict($"Appointment {id} already exist");
            }
            
            

            if (id != appointment.Animal.Id)
            {
                return Results.Conflict($"Animal id not equal to animal id {appointment.Animal.Id} in appointment");
            }
            amongusDB.amongusList.Add(appointment);
            return Results.Created($"/api/animals/{id}/amongus", appointment);
        }
        else
        {
            return Results.NotFound($"Animal {id} not found");
        }
    });



app.UseHttpsRedirection();
app.Run();

