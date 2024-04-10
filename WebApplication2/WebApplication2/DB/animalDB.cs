using WebApplication2.Models;

namespace WebApplication2.DB;

public class animalDB
{
    public static List<Animal> Animals = new()
    {
        new Animal{furColor = "purple", Id = 1,Mass = 1.0,Name = "amogus",Type = "aboba"}
    };
}