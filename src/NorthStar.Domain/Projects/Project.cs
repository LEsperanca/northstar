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

    private Project(Guid id, ProjectName name, Description description, DateTime beginDate, DateTime? endDate, Person? lead, IList<WorkItem> workItems) : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.BeginDate = beginDate;
        this.EndDate = endDate;
        this.Lead = lead;
        this.WorkItems = workItems;
    }

    private Project(Guid id, ProjectName name, Description description) : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.BeginDate = DateTime.UtcNow;
        this.WorkItems = [];
    }

    private Project(Guid id) : base(id) 
    {
        this.Name = ProjectName.NoName;
        this.Description = Description.NoDescription;
        this.WorkItems = [];
    }

    public ProjectName Name { get; private set; }

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
        var project = new Project(Guid.NewGuid(), projectName, description);

        return project;
    }

    public static Project Create(Guid id)
    {
        //TODO validate Guid default value, or null

        var project = new Project(id);

        return project;
    }
}