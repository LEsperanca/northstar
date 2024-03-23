using FluentAssertions;
using NorthStar.Domain.Projects;

namespace Northstar.Domain.UnitTests.People;
public class ProjectTests
{
    [Fact]
    public void Create_Should_BeSuccessfull()
    {
        //Arrange
        var projectName = "Project name";
        var projectDescription = "Project Name Description";

        //Act
        var project = Project.Create(projectName, projectDescription);

        //Assert
        project.Id.Should().NotBeEmpty();
        project.Should().NotBeNull();
        project.Name.Value.Should().Be(projectName);
        project.Description.Value.Should().Be(projectDescription);
    }

    [Fact]
    public void CreateWithNullProjectName_Should_ThrowException()
    {
        //Arrange
        var projectDescription = "Project Name Description";

        //Act
        Action action = () => Project.Create(null!, projectDescription); 

        //Assert
        action.Should().Throw<ArgumentNullException>()
            .WithMessage("Project name cannot be null or empty. (Parameter 'projectName')");

    }

    [Fact]
    public void CreateWithEmptyProjectName_Should_ThrowException()
    {
        //Arrange
        var projectDescription = "Project Name Description";

        //Act
        Action action = () => Project.Create(string.Empty, projectDescription);

        //Assert
        action.Should().Throw<ArgumentNullException>()
            .WithMessage("Project name cannot be null or empty. (Parameter 'projectName')");

    }

    [Fact]
    public void CreateWithNullProjectDescription_Should_Create()
    {
        //Arrange
        var projectName = "project name";

        //Act
        var project = Project.Create(projectName, null!);

        //Assert
        project.Should().NotBeNull();
        project.Name.Value.Should().Be(projectName);
        project.Description.Value.Should().BeNull();
    }

    [Fact]
    public void CreateWithEmptyProjectDescription_Should_Create()
    {
        //Arrange
        var projectName = "project name";

        //Act
        var project = Project.Create(projectName, string.Empty);

        //Assert
        project.Should().NotBeNull();
        project.Name.Value.Should().Be(projectName);
        project.Description.Value.Should().BeEmpty();
    }
}
