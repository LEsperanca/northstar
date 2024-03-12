namespace NorthStar.Application.Projects.Update;

using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;
using System.Threading;
using System.Threading.Tasks;

internal sealed class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;

    }

    public async Task<Result<Guid>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.projectId, cancellationToken);

        if (project is null)
        {
            return Result.Failure<Guid>(ProjectErrors.NotFound);
        }

        project.UpdateName(request.name);
        project.UpdateDescription(request.description);

        _projectRepository.Update(project);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success<Guid>(project.Id);
    }
}
