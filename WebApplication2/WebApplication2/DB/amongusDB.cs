using WebApplication2.Models;

namespace WebApplication2.DB;

public class amongusDB
{
    public static List<amongus> amongusList = new()
    {
        new amongus
        {
            Date = DateTime.Now,
            Id = 1,
            Animal = animalDB.Animals[0],
            Description = "Medical Checkup",
            Price = 10.99
        },
        new amongus
        {
            Date = DateTime.Now,
            Id = 2,
            Animal = animalDB.Animals[1],
            Description = "pp",
            Price = 12.99
        },
        new amongus
        {
            Date = DateTime.Now,
            Id = 3,
            Animal = animalDB.Animals[2],
            Description = "dabadedabada",
            Price = 14.99
        },
        new amongus
        {
            Date = DateTime.Now,
            Id = 4,
            Animal = animalDB.Animals[3],
            Description = "Grooming",
            Price = 9.99
        },
        new amongus
        {
            Date = DateTime.Now,
            Id = 5,
            Animal = animalDB.Animals[4],
            Description = "Nail clipping (ouch)",
            Price = 11.99
        }
        // Add more amongus objects here if needed
    };
}