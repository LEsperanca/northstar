using NorthStar.Domain.Shared;
using NorthStar.Domain.WorkItems;
namespace NorthStar.Domain.Projects;

using NorthStar.Domain.Abstractions;
using NorthStar.Domain.People;

public class Project : Entity
{
    public Project(Guid id, Name name, Description description, DateTime beginDate, DateTime endDate, Person lead, IList<WorkItem> workItems) : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.BeginDate = beginDate;
        this.EndDate = endDate;
        this.Lead = lead;
        this.WorkItems = workItems;
    }
    
    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public DateTime BeginDate { get; private set; }
    
    public DateTime EndDate { get; private set; }

    public Person Lead { get; private set; }

    public IList<WorkItem> WorkItems { get; private set; }
}