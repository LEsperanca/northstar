using Northstar.Api.FunctionalTests.Infrastructure;
using Northstar.FunctionalTests.Infrastructure;
using NorthStar.Application.Persons.Create;
using System.Net;
using System.Net.Http.Json;

namespace Northstar.Api.FunctionalTests.People;

public class CreatePeopleTests : BaseFunctionalTest
{
    public CreatePeopleTests(FunctionalTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Theory]
    [InlineData("", "name",  "12345")]
    [InlineData("test.com", "name", "12345")]
    [InlineData("@test.com", "name", "12345")]
    [InlineData("test@", "name", "12345")]
    [InlineData("test@test.com", "", "12345")]
    [InlineData("test@test.com", "name", "")]
    [InlineData("test@test.com", "name", "1")]
    [InlineData("test@test.com", "name", "12")]
    [InlineData("test@test.com", "name", "123")]
    [InlineData("test@test.com", "name", "1234")]
    public async Task Create_ShouldReturnBadRequest_WhenRequestIsInvalid(
        string email,
        string name,
        string password)
    {
        // Arrange
        var request = new PersonRequest(email, name, password);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/people", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Create_ShouldReturnOk_WhenRequestIsValid()
    {
        // Arrange
        var request = new PersonRequest("create@test.com", "name", "12345");

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/people", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
