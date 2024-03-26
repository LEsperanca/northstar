using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People;

public class PersonName : ValueObject
{
    public string Value { get; private set; }

    public PersonName(string name) 
    {
        if(string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name", "Person Name cannot be null or empty.");
        }

        Value = name; 
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value ;
    }

    public static implicit operator PersonName(string name) => new (name);

    public override string ToString() => Value;
}