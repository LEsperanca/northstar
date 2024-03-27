using Northstar.Api.FunctionalTests.Infrastructure;
using Northstar.FunctionalTests.Infrastructure;
using NorthStar.Api.Controllers.Projects;
using NorthStar.Application.Persons.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Northstar.Api.FunctionalTests.People;
public class LoginPeopleTests : BaseFunctionalTest
{
    private const string Email = "login@test.com";
    private const string Password = "12345";

    public LoginPeopleTests(FunctionalTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Login_ShouldReturnUnauthorized_WhenUserDoesNotExist()
    {
        // Arrange
        var request = new LoginPersonRequest(Email, Password);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/people/login", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Login_ShouldReturnOk_WhenUserExists()
    {
        // Arrange
        var registerRequest = new PersonRequest(Email, "nameq", Password);
        await HttpClient.PostAsJsonAsync("api/v1/people", registerRequest);

        var request = new LoginPersonRequest(Email, Password);

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/v1/people/login", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}