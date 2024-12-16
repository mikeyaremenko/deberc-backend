using System.Net;
using System.Text;
using DebercBackend.IntegrationTests.Config;
using FluentAssertions;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerCollection")]
public class CreateTests(ITestOutputHelper helper) : BaseTest(helper)
{
    public override string ApiUrl => "/api/v1/games";

    private const string GameJsonPayload = "./Data/Game.json";

    [Fact]
    public async Task CreatesGame_WithValidPayload()
    {
        string jsonContent = await File.ReadAllTextAsync(GameJsonPayload);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(ApiUrl, content);

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var createdId = int.Parse(responseBody);
        createdId.Should().BeGreaterThan(0, because: "the value must be positive and greater than zero.");
    }

    [Fact]
    public async Task BadRequest_WithEmptyPayload()
    {
        var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(ApiUrl, content);

        string responseBody = await response.Content.ReadAsStringAsync();
        responseBody.Should().Contain("Name is required", because: "Name is required.");
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest, because: "Empty payload was provided.");
    }
}
