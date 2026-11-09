using System;
using System.Collections.Generic;
using OopLab2.Core;

namespace OopLab2.ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        CollectionsDemo.Run();

        Console.WriteLine("\nBinary Tree demo:");

        Student s1 = new Student("S105", "Name1 LastName1", 2004, "KB-21", 2);
        Student s2 = new Student("S102", "Name2 LastName2", 2005, "KB-11", 1);
        Student s3 = new Student("S108", "Name3 LastName3", 2003, "KB-31", 3);
        Student s4 = new Student("S101", "Name4 LastName4", 2006, "KB-11", 1);
        Student s5 = new Student("S103", "Name5 LastName5", 2004, "KB-21", 2);
        Student s6 = new Student("S106", "Name6 LastName6", 2002, "KB-41", 4);

        Console.WriteLine("\n--- 1. Binary Tree (ordered by StudentId via IComparable<T>) ---");
        BinaryTree<Student> tree = new BinaryTree<Student>();

        tree.Add(s1);
        tree.Add(s2);
        tree.Add(s3);
        tree.Add(s4);
        tree.Add(s5);
        tree.Add(s6);

        Console.WriteLine($"Total nodes in tree: {tree.Count}");

        Console.WriteLine($"Tree contains S103: {tree.Contains(s5)}");
        Student nonExistent = new Student("S999", "Name0 LastName0", 2000, "None", 1);
        Console.WriteLine($"Tree contains S999: {tree.Contains(nonExistent)}");

        Console.WriteLine("\nPreorder Traversal (Root -> Left -> Right) using custom IEnumerator<T>:");
        int order = 1;
        foreach (Student student in tree)
        {
            Console.WriteLine($"  {order++}. {student}");
        }

        Console.WriteLine("\n--- 2. Binary Tree using custom IComparer<T> (StudentAgeComparer) ---");
        BinaryTree<Student> ageTree = new BinaryTree<Student>(new StudentAgeComparer());

        ageTree.Add(s1);
        ageTree.Add(s2);
        ageTree.Add(s3);
        ageTree.Add(s4);
        ageTree.Add(s5);
        ageTree.Add(s6);

        Console.WriteLine("Preorder Traversal of age-ordered tree:");
        order = 1;
        foreach (Student student in ageTree)
        {
            Console.WriteLine($"  {order++}. {student}");
        }

        Console.WriteLine("\n--- 3. Demonstration of Sorting with IComparable vs IComparer ---");
        List<Student> listToSort = new List<Student>() { s1, s2, s3, s4, s5, s6 };

        Console.WriteLine("Original list:");
        foreach (var s in listToSort) Console.WriteLine($"  {s.StudentId} - {s.FullName} ({s.BirthYear})");

        listToSort.Sort();
        Console.WriteLine("\nSorted by StudentId (via IComparable<Student>):");
        foreach (var s in listToSort) Console.WriteLine($"  {s.StudentId} - {s.FullName} ({s.BirthYear})");

        listToSort.Sort(new StudentAgeComparer());
        Console.WriteLine("\nSorted by BirthYear (via StudentAgeComparer : IComparer<Student>):");
        foreach (var s in listToSort) Console.WriteLine($"  {s.StudentId} - {s.FullName} ({s.BirthYear})");
    }
}
