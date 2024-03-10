using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.WorkItems;

public class Summary : ValueObject
{
    public string Value { get; private set; }
    public Summary(string summary)
    {
        this.Value = summary;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}