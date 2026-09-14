namespace vOopLab1.DataAccess.Domain;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
