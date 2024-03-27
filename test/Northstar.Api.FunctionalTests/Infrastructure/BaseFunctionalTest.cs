using Northstar.Api.FunctionalTests.People;
using Northstar.FunctionalTests.Infrastructure;
using NorthStar.Api.Controllers.Projects;
using NorthStar.Application.Persons.Login;
using System.Net.Http.Json;

namespace Northstar.Api.FunctionalTests.Infrastructure;
public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>
{
    protected readonly HttpClient HttpClient;

    protected BaseFunctionalTest(FunctionalTestWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }

    protected async Task<string> GetAccessToken()
    {
        HttpResponseMessage loginResponse = await HttpClient.PostAsJsonAsync(
            "api/v1/people/login",
        new LoginPersonRequest(
                PeopleData.PersonRequest.Email,
                PeopleData.PersonRequest.Password));

        AccessTokenResponse? accessTokenResponse = await loginResponse.Content.ReadFromJsonAsync<AccessTokenResponse>();

        return accessTokenResponse!.AccessToken;
    }
}
