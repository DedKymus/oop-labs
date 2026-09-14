using System;

namespace vOopLab1.DataAccess.Domain;

public class Student : Person, ISingable
{
    public int Year { get; set; }
    public string StudentId { get; set; }
    public DateTime BirthDate { get; set; }

    public Student(string firstName, string lastName, int year, string studentId, DateTime birthDate) 
        : base(firstName, lastName)
    {
        Year = year;
        StudentId = studentId;
        BirthDate = birthDate;
    }

    public void Sing()
    {
        Console.WriteLine($"Student {FirstName} {LastName} is singing.");
    }
}
