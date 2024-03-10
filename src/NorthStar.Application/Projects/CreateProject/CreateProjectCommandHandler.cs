using NorthStar.Application.Abstractions.Messaging;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;

namespace NorthStar.Application.Projects.CreateProject;

internal sealed class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _repository = projectRepository;
        _unitOfWork = unitOfWork;

    }

    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = Project.Create(request.name, request.description);

        _repository.Add(project);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return project.Id;
    }
}
