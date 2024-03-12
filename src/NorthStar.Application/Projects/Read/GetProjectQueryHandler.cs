using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;

namespace NorthStar.Application.Projects.Read;

internal sealed class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectResponse>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<ProjectResponse>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var result = await _projectRepository.GetByIdAsync(request.projectId, cancellationToken);

        if (result == null)
        {
            return Result.Failure<ProjectResponse>(ProjectErrors.NotFound);
        }

        var projectResponse = new ProjectResponse(
            result.Id,
            result.Name.Value,
            result.Description.Value,
            result.BeginDate,
            result.EndDate,
            result.Lead?.Name.Value,
            []);

        return Result.Success(projectResponse);
    }
}
