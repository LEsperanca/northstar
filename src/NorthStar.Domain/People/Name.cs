using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People;

public class Name : ValueObject
{

    public string Value { get; private set; }

    public Name(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value ;
    }
}