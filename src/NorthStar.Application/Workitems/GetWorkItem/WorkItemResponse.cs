namespace NorthStar.Application.Workitems.GetWorkItem;

public sealed class WorkItemResponse
{
    public string? Type { get; private set; }

    public string? Summary { get; private set; }

    public string? Description { get; private set; }

    public string? Priority { get; private set; }

    public string? Resolution { get; private set; }

    public string? Assignee { get; private set; }

    public string? Reporter { get; private set; }

    public string? Status { get; set; }

    public DateTime BeginDate { get; private set; }

    public DateTime EndDate { get; private set; }
}
