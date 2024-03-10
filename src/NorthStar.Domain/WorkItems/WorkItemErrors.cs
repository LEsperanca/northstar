using NorthStar.Domain.Abstractions;

namespace NorthStar.Domain.WorkItems;
public static class WorkItemErrors
{
    public static Error NotFound = new Error(
        "WorkItem.NotFound",
        "The work item with the specified id was not found");
}
