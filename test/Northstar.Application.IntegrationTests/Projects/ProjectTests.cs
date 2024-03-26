using FluentAssertions;
using Northstar.Application.IntegrationTests.Infrastructure;
using NorthStar.Application.Projects.ReadById;

namespace Northstar.Application.IntegrationTests.Projects;

public class ProjectTests : BaseIntegrationTest
{
    public ProjectTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetProject_Should_ReturnProject()
    {
        //Arrange
        var query = new GetProjectQuery(new Guid("957c4d17-d207-4cef-b146-3acea97c5e40"));

        //Act
        var result = await _sender.Send(query);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }
}