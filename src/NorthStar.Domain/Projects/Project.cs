using NorthStar.Domain.WorkItems;
namespace NorthStar.Domain.Projects;

using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;

public class Project : Entity
{
    private Project()
    {
        Name = null!;
        Description = null!;
        WorkItems = [];
    }

    private Project(Guid id, Name name, Description description, DateTime beginDate, DateTime? endDate, Person? lead, IList<WorkItem> workItems) : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.BeginDate = beginDate;
        this.EndDate = endDate;
        this.Lead = lead;
        this.WorkItems = workItems;
    }

    private Project(Guid id, Name name, Description description) : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.BeginDate = DateTime.UtcNow;
        this.WorkItems = [];
    }

    private Project(Guid id) : base(id) 
    {
        this.Name = new Name(string.Empty);
        this.Description = new Description(string.Empty);
        this.WorkItems = [];
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public DateTime BeginDate { get; private set; }
    
    public DateTime? EndDate { get; private set; }

    public Person? Lead { get; private set; }

    public IList<WorkItem> WorkItems { get; private set; }

    public void UpdateName(string name)
    {
        this.Name = new(name);
    }

    public void UpdateDescription(string description)
    {
        this.Description = new(description);
    }

    public static Project Create(string projectName, string description)
    {
        var project = new Project(Guid.NewGuid(), new Name(projectName), new Description(description));

        return project;
    }

    public static Project Create(Guid id)
    {
        var project = new Project(id);

        return project;
    }
}