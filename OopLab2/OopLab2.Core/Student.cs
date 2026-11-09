using System;

namespace OopLab2.Core;

public class Student : IComparable<Student>
{
    public string StudentId { get; set; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string GroupNumber { get; set; }
    public int Course { get; set; }

    public Student(string studentId, string fullName, int birthYear, string groupNumber, int course = 1)
    {
        StudentId = studentId;
        FullName = fullName;
        BirthYear = birthYear;
        GroupNumber = groupNumber;
        Course = course;
    }

    public void AdvanceCourse()
    {
        Course++;
    }

    public int GetAge(int currentYear = 2026)
    {
        return currentYear - BirthYear;
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return StudentId.CompareTo(other.StudentId);
    }

    public override string ToString()
    {
        return $"[{StudentId}] {FullName}, Course: {Course}, Group: {GroupNumber}, Born: {BirthYear} (Age: {GetAge()})";
    }
}
