using Moq;
using NorthStar.Application.Projects.Create;
using NorthStar.Application.Projects.Delete;
using NorthStar.Application.Projects.ReadById;
using NorthStar.Application.Projects.Update;
using NorthStar.Domain.Abstractions;
using NorthStar.Domain.Projects;
using NorthStar.Domain.Projects.Repository;

namespace Northstar.Application.UnitTests.Projects;

public class ProjectTests
{
    private readonly Mock<IProjectRepository> _projectRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public ProjectTests()
    {
        _projectRepositoryMock = new Mock<IProjectRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        

    }

    [Fact]
    public async Task Handle_Should_CreateProject()
    {
        //Arrange
        _projectRepositoryMock.Setup(pr => pr.Add(It.IsAny<Project>()));
        _unitOfWorkMock.Setup(uw => uw.SaveChangesAsync(It.IsAny<CancellationToken>()));

        var createProjectCommandHandler = new CreateProjectCommandHandler(_projectRepositoryMock.Object, _unitOfWorkMock.Object);
        var createProjectCommand = new CreateProjectCommand("Project Name", "Project Description");

        //Act
        var result = await createProjectCommandHandler.Handle(createProjectCommand, default);

        //Assert
        result.Should().NotBeNull();
        result.Value.Should<Guid>().NotBeNull();
    }

    [Fact]
    public async Task Handle_Should_ReadProjectById()
    {
        //Arrange
        var project = Project.Create("Project Name", "Project String");

        _projectRepositoryMock
            .Setup(pr => pr.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => project);

        var getProjectQuery = new GetProjectQuery(It.IsAny<Guid>());
        var getProjectQueryHandler = new GetProjectQueryHandler(_projectRepositoryMock.Object);

        //Act
        var result = await getProjectQueryHandler.Handle(getProjectQuery, default);

        //Assert
        result.Should().NotBeNull();
        result.Value.Name.Should().Be(project.Name.Value);
        result.Value.Description.Should().Be(project.Description.Value);
    }

    [Fact]
    public async Task Handle_Should_ResultInErrorNotFound()
    {
        //Arrange
        _projectRepositoryMock
            .Setup(pr => pr.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => null);

        var getProjectQuery = new GetProjectQuery(It.IsAny<Guid>());
        var getProjectQueryHandler = new GetProjectQueryHandler(_projectRepositoryMock.Object);

        //Act
        var result = await getProjectQueryHandler.Handle(getProjectQuery, default);

        //Assert
        result.Error.Should().NotBeNull();
        result.Error.Should().Be(ProjectErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_UpdateProject()
    {
        //Arrange
        var project = Project.Create("Project Name", "Project Description");
        
        _projectRepositoryMock
            .Setup(pr => pr.GetByIdAsync(project.Id, default))
            .ReturnsAsync(project);

        var projectNameUpdated = "Project Name Updated";
        var projectDescriptionUpdated = "Project Description Updated";

        var updateProjectCommand = new UpdateProjectCommand(project.Id, projectNameUpdated, projectDescriptionUpdated);
        var updateProjectCommandHandler = new UpdateProjectCommandHandler(_projectRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        var result = await updateProjectCommandHandler.Handle(updateProjectCommand, default);

        //Assert
        result.Should().NotBeNull();
        result.Value.Should().Be(project.Id);
    }

    [Fact]
    public async Task Handle_Should_DeleteProject()
    {
        //Arrange
        _projectRepositoryMock.Setup(pr => pr.Delete(It.IsAny<Project>()));
        var guid = Guid.NewGuid();
        var deleteProjectCommand = new DeleteProjectCommand(guid);
        var deleteProjectCommandHandler = new DeleteProjectCommandHandler(_projectRepositoryMock.Object, _unitOfWorkMock.Object);

        //Act
        var result = await deleteProjectCommandHandler.Handle(deleteProjectCommand, default);

        //Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        _projectRepositoryMock.Verify(repo => repo.Delete(It.Is<Project>(p => p.Id == guid )), Times.Once);
    }
}