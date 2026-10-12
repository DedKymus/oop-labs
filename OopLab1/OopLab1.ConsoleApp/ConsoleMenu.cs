using System;
using System.Collections.Generic;
using System.Linq;
using vOopLab1.DataAccess;
using vOopLab1.DataAccess.Domain;

namespace OopLab1.ConsoleApp;

public class ConsoleMenu
{
    private readonly FileRepository _repository;
    private List<Person> _persons;

    public ConsoleMenu(string filePath)
    {
        _repository = new FileRepository(filePath);
        _persons = new List<Person>();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Load data from file");
            Console.WriteLine("2. Save data to file");
            Console.WriteLine("3. Show all records");
            Console.WriteLine("4. 3rd year students born in summer");
            Console.WriteLine("5. Demonstrate skills (Sing)");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1": LoadData(); break;
                case "2": SaveData(); break;
                case "3": ShowAll(); break;
                case "4": ExecuteVariantTask(); break;
                case "5": DemonstrateSkills(); break;
                case "0": exit = true; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void LoadData()
    {
        _persons = _repository.ReadAll();
        Console.WriteLine($"Loaded {_persons.Count} records.");
    }

    private void SaveData()
    {
        _repository.SaveAll(_persons);
        Console.WriteLine("Data successfully saved.");
    }

    private void ShowAll()
    {
        if (_persons.Count == 0)
        {
            Console.WriteLine("No data available. Please load from file first.");
            return;
        }

        foreach (var p in _persons)
        {
            Console.WriteLine($"- {p.GetType().Name}: {p.FirstName} {p.LastName}");
            if (p is Student s)
            {
                Console.WriteLine($"    Year: {s.Year}, Student ID: {s.StudentId}, Birth Date: {s.BirthDate.ToShortDateString()}");
            }
        }
    }

    
    private void ExecuteVariantTask()
    {
        int count = 0;
        Console.WriteLine("3rd year summer students:");

        foreach (var p in _persons)
        {
            if (p is Student s)
            {
                if (s.Year == 3)
                {
                    if (s.BirthDate.Month == 6 || s.BirthDate.Month == 7 || s.BirthDate.Month == 8)
                    {
                        count++;
                        Console.WriteLine($"- {s.FirstName} {s.LastName} ({s.BirthDate.ToShortDateString()})");
                    }
                }
            }
        }

        Console.WriteLine($"Total count: {count}");
    }

    private void DemonstrateSkills()
    {
        foreach (var p in _persons)
        {
            if (p is ISingable singable)
            {
                singable.Sing();
            }
        }
    }
}
