using System;
using System.Collections.Generic;
using System.IO;
using vOopLab1.DataAccess.Domain;

namespace vOopLab1.DataAccess;

public class FileRepository
{
    private readonly string _filePath;

    public FileRepository(string filePath)
    {
        _filePath = filePath;
    }

    // reads all records from the file and parses them into a list of persons
    public List<Person> ReadAll()
    {
        var persons = new List<Person>();
        if (!File.Exists(_filePath)) return persons;

        string[] lines = File.ReadAllLines(_filePath);
        
        string currentType = "";
        Dictionary<string, string> currentProps = new Dictionary<string, string>();
        bool isReadingObj = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            if (line == "{")
            {
                isReadingObj = true;
                currentProps.Clear();
                continue;
            }

            if (line == "};" || line == "}")
            {
                isReadingObj = false;
                
                string fName = "Unknown";
                if (currentProps.ContainsKey("firstname")) fName = currentProps["firstname"];
                
                string lName = "Unknown";
                if (currentProps.ContainsKey("lastname")) lName = currentProps["lastname"];

                if (currentType == "Student")
                {
                    int year = 1;
                    if (currentProps.ContainsKey("year"))
                    {
                        int.TryParse(currentProps["year"], out year);
                    }

                    string sId = "None";
                    if (currentProps.ContainsKey("studentid")) sId = currentProps["studentid"];
                    
                    DateTime bDate = new DateTime(2000, 1, 1);
                    if (currentProps.ContainsKey("birthdate"))
                    {
                        DateTime.TryParse(currentProps["birthdate"], out bDate);
                    }

                    persons.Add(new Student(fName, lName, year, sId, bDate));
                }
                else if (currentType == "Teacher")
                {
                    persons.Add(new Teacher(fName, lName));
                }
                else if (currentType == "Astronaut")
                {
                    persons.Add(new Astronaut(fName, lName));
                }
                
                continue;
            }

            if (isReadingObj)
            {
                // clean up the line from quotes and commas
                string cleanLine = line.Replace("\"", "").Replace(",", "");
                string[] parts = cleanLine.Split(':');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim().ToLower();
                    string val = parts[1].Trim();
                    currentProps[key] = val;
                }
            }
            else
            {
                string[] header = line.Split(' ');
                if (header.Length > 0)
                {
                    currentType = header[0];
                }
            }
        }

        return persons;
    }

    public void SaveAll(List<Person> persons)
    {
        using var writer = new StreamWriter(_filePath);
        foreach (var person in persons)
        {
            string type = person.GetType().Name;
            writer.WriteLine($"{type} {person.FirstName}{person.LastName}");
            writer.WriteLine("{");
            writer.WriteLine($"  \"firstname\": \"{person.FirstName}\",");
            
            if (person is Student s)
            {
                writer.WriteLine($"  \"lastname\": \"{person.LastName}\",");
                writer.WriteLine($"  \"studentid\": \"{s.StudentId}\",");
                writer.WriteLine($"  \"year\": \"{s.Year}\",");
                writer.WriteLine($"  \"birthdate\": \"{s.BirthDate.ToString("dd-MM-yyyy")}\"");
            }
            else
            {
                writer.WriteLine($"  \"lastname\": \"{person.LastName}\"");
            }
            writer.WriteLine("};");
        }
    }
}
