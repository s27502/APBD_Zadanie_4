using WebApplication2.Models;

namespace WebApplication2.DB;

public class animalDB
{
    public static List<Animal> Animals = new()
    {
        new Animal{ furColor = "purple", Id = 1, Mass = 1.0, Name = "amogus", Type = "aboba" },
        new Animal{ furColor = "red", Id = 2, Mass = 0.8, Name = "redSussy", Type = "suspecticus" },
        new Animal{ furColor = "blue", Id = 3, Mass = 1.2, Name = "blueCrew", Type = "crewmatus" },
        new Animal{ furColor = "white", Id = 3, Mass = 1.2, Name = "dog", Type = "dog" },
        new Animal{ furColor = "orange", Id = 3, Mass = 1.2, Name = "Ratchet", Type = "cat" }
    };
}