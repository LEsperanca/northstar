using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string email)
    {
        // TODO Validate Email

        Value = email;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}