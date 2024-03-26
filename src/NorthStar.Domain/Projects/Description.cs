using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.Projects;

public class Description : ValueObject
{
    public string Value { get; private set; }

    public static Description NoDescription = new Description("NoDescription");

    public Description(string description)
    {
        Value = description;
    }

    public static implicit operator Description(string description) => new(description);

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}