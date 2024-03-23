using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.Projects;

public class ProjectName : ValueObject
{
    public string Value { get; private set; }

    public static ProjectName NoName = new ProjectName("NoName");


    public ProjectName(string projectName)
    {
        if (string.IsNullOrEmpty(projectName))
        {
            throw new ArgumentNullException("projectName", "Project name cannot be null or empty.");
        }

        Value = projectName;
    }

    public static implicit operator ProjectName(string projectName) => new(projectName);

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    
}