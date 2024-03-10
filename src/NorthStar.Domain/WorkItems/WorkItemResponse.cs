namespace NorthStar.Domain.WorkItems;
public sealed class WorkItemResponse
{
    public WorkItemType Type { get; private set; }

    public string? Summary { get; private set; }

    public string? Description { get; private set; }

    public Priority Priority { get; private set; }

    public Resolution Resolution { get; private set; }

    public string? Assignee { get; private set; }

    public string? Reporter { get; private set; }

    public Status Status { get; set; }

    public DateTime BeginDate { get; private set; }

    public DateTime EndDate { get; private set; }
}
