using NorthStar.Application.Workitems.GetWorkItem;

namespace NorthStar.Application.Projects.GetProject;

public sealed class ProjectResponse
{
    public Guid? Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public DateTime? BeginDate { get; init; }

    public DateTime? EndDate { get; init; }

    public string? Lead { get; init; }

    public IList<WorkItemResponse>? WorkItems { get; init; }

    public ProjectResponse(Guid? id, string? name, string? description, DateTime? beginDate, DateTime? endDate, string? lead, IList<WorkItemResponse>? workItems)
    {
        Id = id;
        Name = name;
        Description = description;
        BeginDate = beginDate;
        EndDate = endDate;
        Lead = lead;
        WorkItems = workItems;
    }
}
