using System;
using System.Collections.Generic;

namespace OopLab2.Core;

public class StudentAgeComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;
        return x.BirthYear.CompareTo(y.BirthYear);
    }
}

public class StudentNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;
        return string.Compare(x.FullName, y.FullName);
    }
}
