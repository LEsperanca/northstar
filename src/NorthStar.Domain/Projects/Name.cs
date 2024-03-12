using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.Projects;

public class Name : ValueObject
{
    public string Value { get; private set; }

    public static Name NoName = new Name("NoName");


    public Name(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException();
        }

        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    
}