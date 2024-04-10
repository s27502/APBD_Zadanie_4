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
    return Results.Ok(animalDB.Animals);
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
    animalDB.Animals.Add(student);
    return Results.Created($"/api/animals/{student.Id}", student);
});

// PUT api/students/1
app.MapPut("/api/animals/{id:int}", (int id, [FromBody] Animal data) =>
{
    var student = animalDB.Animals.FirstOrDefault(st => st.Id == id);
    if (student is null) return Results.NotFound($"Animal with id {id} not found");
    
    student.Name = data.Name;
    student.Type = data.Type;
    student.furColor = data.furColor;
    student.Mass = data.Mass;
    
    return Results.Ok(student);
});

app.MapDelete("/api/animals/{id:int}", (int id) =>
{
    var students = animalDB.Animals.Where(st => st.Id != id);
    animalDB.Animals = students.ToList();
    return Results.Ok();
});

app.MapGet("/api/animals/{id:int}/amongus", (int id) =>
{

});

app.MapPost("/api/animals/{id:int}/amongus", 
    (int id, [FromBody] amongus appointment) =>
    {

    });



app.UseHttpsRedirection();
app.Run();

