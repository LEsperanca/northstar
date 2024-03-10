using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.Projects;
public static class ProjectErrors
{
    public static Error NotFound = new Error(
        "Project.NotFound", 
        "The project with the specified identifier was not found");
}
