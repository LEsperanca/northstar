using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.WorkItems;
public class Description : ValueObject
{
    public string Value { get; set; }
    public Description(string description)
    {
        Value = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
