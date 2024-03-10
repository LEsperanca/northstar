using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.People;
public static class PersonErrors
{
    public static Error NotFound = new Error(
        "Person.NotFound", 
        "The person with the specified identifier was not not found");
}
