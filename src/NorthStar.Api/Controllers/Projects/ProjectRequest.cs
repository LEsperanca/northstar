namespace NorthStar.Api.Controllers.Projects;

public sealed record ProjectRequest
{
    public Guid Id { get; private set; } = default;

    public string Name { get; private set; }

    public string Description { get; private set; }

    public ProjectRequest(Guid id, string name, string descripton)
    {
        this.Id = id;
        this.Name = name;
        this.Description = descripton;
    }
}