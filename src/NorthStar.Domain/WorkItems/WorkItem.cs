namespace NorthStar.Domain.WorkItems;

using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;
using NorthStar.Domain.Projects;

public class WorkItem : Entity
{
    private WorkItem()
    {
        Project = null!;
        Summary = null!;
        Description = null!;
        Assignee = null!;
        Reporter = null!;
    }

    public WorkItem(Guid id, Project project, WorkItemType type, Summary summary, Description description, Priority priority, Resolution resolution, Person assignee, Person reporter, DateTime beginDate, DateTime endDate, Status status) : base(id)
    {
        Project = project;
        Type = type;
        Summary = summary;
        Description = description;
        Priority = priority;
        Resolution = resolution;
        Assignee = assignee;
        Reporter = reporter;
        BeginDate = beginDate;
        EndDate = endDate;
        Status = status;
    }

    public Project Project { get; private set; }

    public WorkItemType Type { get; private set; }

    public Summary Summary { get; private set; }

    public Description Description { get; private set; }

    public Priority Priority { get; private set; }

    public Resolution Resolution { get; private set; }

    public Person Assignee { get; private set; }

    public Person Reporter { get; private set; }

    public Status Status { get; set; }

    public DateTime BeginDate { get; private set; }

    public DateTime EndDate { get; private set; }

}