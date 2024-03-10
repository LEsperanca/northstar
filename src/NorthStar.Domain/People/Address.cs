using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People;

public class Address : ValueObject
{



    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}