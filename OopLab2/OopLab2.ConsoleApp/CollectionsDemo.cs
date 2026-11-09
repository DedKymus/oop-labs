using System;
using System.Collections;
using System.Collections.Generic;
using OopLab2.Core;

namespace OopLab2.ConsoleApp;

public static class CollectionsDemo
{
    public static void Run()
    {
        Console.WriteLine("Collections test: Array, ArrayList, List<T>");

        Student s1 = new Student("S101", "Name1 LastName1", 2004, "KB-21", 2);
        Student s2 = new Student("S102", "Name2 LastName2", 2005, "KB-11", 1);
        Student s3 = new Student("S103", "Name3 LastName3", 2003, "KB-31", 3);

        Console.WriteLine("\n--- 1. Fixed-size Array (Student[]) ---");
        Student[] studentArray = new Student[3] { s1, s2, s3 };

        Console.WriteLine("Traversal (initial array):");
        for (int i = 0; i < studentArray.Length; i++)
        {
            Console.WriteLine($"  [{i}] {studentArray[i]}");
        }

        studentArray[1].GroupNumber = "KB-12";
        Console.WriteLine($"Updated student at index 1: {studentArray[1]}");

        string searchId = "S103";
        Student? foundInArray = null;
        for (int i = 0; i < studentArray.Length; i++)
        {
            if (studentArray[i] != null && studentArray[i].StudentId == searchId)
            {
                foundInArray = studentArray[i];
                break;
            }
        }
        Console.WriteLine($"Search '{searchId}' in array: {(foundInArray != null ? foundInArray.ToString() : "Not found")}");

        Console.WriteLine("Note: Adding or removing in arrays requires allocating a new array (fixed size).");
        Student[] resizedArray = new Student[studentArray.Length + 1];
        Array.Copy(studentArray, resizedArray, studentArray.Length);
        resizedArray[3] = new Student("S104", "Name4 LastName4", 2004, "KB-21", 2);
        Console.WriteLine($"Array resized to length {resizedArray.Length}, added element: {resizedArray[3].FullName}");

        Console.WriteLine("\n--- 2. Non-generic Collection (ArrayList) ---");
        ArrayList arrayList = new ArrayList();

        arrayList.Add(s1);
        arrayList.Add(s2);
        arrayList.Add(s3);
        Console.WriteLine($"Added 3 elements. Current count: {arrayList.Count}");

        Student s4 = new Student("S104", "Name4 LastName4", 2004, "KB-21", 2);
        arrayList.Add(s4);

        if (arrayList.Count > 0 && arrayList[0] is Student student0)
        {
            student0.AdvanceCourse();
            Console.WriteLine($"Updated student at index 0 (advanced course): {student0}");
        }

        Student? foundInArrayList = null;
        foreach (object item in arrayList)
        {
            if (item is Student studentItem && studentItem.StudentId == searchId)
            {
                foundInArrayList = studentItem;
                break;
            }
        }
        Console.WriteLine($"Search '{searchId}' in ArrayList: {(foundInArrayList != null ? foundInArrayList.ToString() : "Not found")}");

        arrayList.Remove(s4);
        Console.WriteLine($"Removed s4. Current count: {arrayList.Count}");

        Console.WriteLine("Traversal (ArrayList requires casting object -> Student):");
        foreach (object obj in arrayList)
        {
            Student currentStudent = (Student)obj;
            Console.WriteLine($"  {currentStudent}");
        }

        Console.WriteLine("\n--- 3. Generic Collection (List<Student>) ---");
        List<Student> genericList = new List<Student>();

        genericList.Add(s1);
        genericList.Add(s2);
        genericList.Add(s3);
        genericList.Add(s4);
        Console.WriteLine($"Added 4 elements. Current count: {genericList.Count}");

        genericList[1].AdvanceCourse();
        Console.WriteLine($"Updated index 1: {genericList[1]}");

        Student? foundInList = null;
        for (int i = 0; i < genericList.Count; i++)
        {
            if (genericList[i].StudentId == searchId)
            {
                foundInList = genericList[i];
                break;
            }
        }
        Console.WriteLine($"Search '{searchId}' in List<Student>: {(foundInList != null ? foundInList.ToString() : "Not found")}");

        genericList.Remove(s4);
        Console.WriteLine($"Removed s4. Current count: {genericList.Count}");

        Console.WriteLine("Traversal (List<Student> is strongly typed, no cast needed):");
        foreach (Student student in genericList)
        {
            Console.WriteLine($"  {student}");
        }
    }
}
