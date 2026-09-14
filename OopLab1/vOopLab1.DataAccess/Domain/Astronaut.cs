using System;

namespace vOopLab1.DataAccess.Domain;

public class Astronaut : Person, ISingable
{
    public string Mission { get; set; }

    public Astronaut(string firstName, string lastName, string mission = "Mars") 
        : base(firstName, lastName)
    {
        Mission = mission;
    }

    public void Sing()
    {
        Console.WriteLine($"Astronaut {FirstName} {LastName} is singing.");
    }
}
