using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;

namespace NorthStar.Application.Projects.Delete;

internal sealed class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;

    }

    public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = Project.Create(request.projectId);

        _projectRepository.Delete(project);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
