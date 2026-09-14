using OopLab1.ConsoleApp;
using System.IO;

string filePath = "data.txt";

if (!File.Exists(filePath))
{
    string[] initialData = new string[]
    {
        "Student Name1LastName1",
        "{",
        "  \"firstname\": \"Name1\",",
        "  \"lastname\": \"LastName1\",",
        "  \"studentid\": \"KB123456\",",
        "  \"year\": \"3\",",
        "  \"birthdate\": \"15-07-2003\"",
        "};",
        "Student Name2LastName2",
        "{",
        "  \"firstname\": \"Name2\",",
        "  \"lastname\": \"LastName2\",",
        "  \"studentid\": \"KB111111\",",
        "  \"year\": \"3\",",
        "  \"birthdate\": \"20-12-2003\"",
        "};",
        "Teacher Name3LastName3",
        "{",
        "  \"firstname\": \"Name3\",",
        "  \"lastname\": \"LastName3\"",
        "};",
        "Astronaut Name4LastName4",
        "{",
        "  \"firstname\": \"Name4\",",
        "  \"lastname\": \"LastName4\"",
        "};"
    };
    File.WriteAllLines(filePath, initialData);
}

var menu = new ConsoleMenu(filePath);
menu.Run();