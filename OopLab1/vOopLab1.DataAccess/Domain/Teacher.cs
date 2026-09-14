using System;

namespace vOopLab1.DataAccess.Domain;

public class Teacher : Person, ISingable
{
    public string Subject { get; set; }

    public Teacher(string firstName, string lastName, string subject = "OOP") 
        : base(firstName, lastName)
    {
        Subject = subject;
    }

    public void Sing()
    {
        Console.WriteLine($"Teacher {FirstName} {LastName} is singing.");
    }
}
