using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.Projects;

public class Description : ValueObject
{
    public string Value { get; private set; }

    public Description(string description)
    {
        Value = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}