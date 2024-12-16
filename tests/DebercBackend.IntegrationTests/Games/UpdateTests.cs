using System.Net;
using System.Text;
using DebercBackend.Core.GameAggregate;
using DebercBackend.IntegrationTests.Config;
using DebercBackend.IntegrationTests.Utilities;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerCollection")]
public class UpdateTests(ITestOutputHelper helper) : BaseTest(helper)
{
    public override string ApiUrl => GameUtility.ApiUrl;

    private const string UpdateGameJsonPayload = "./Data/UpdateGame.json";

    [Fact]
    public async Task UpdatesGame_WithValidPayload()
    {
        var responseBody = await GameUtility.CreateGame(_client);
        var createdId = int.Parse(responseBody);
        string jsonContent = await File.ReadAllTextAsync(UpdateGameJsonPayload);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var url = $"{ApiUrl}/{createdId}";

        var response = await _client.PutAsync(url, content);

        response.EnsureSuccessStatusCode();
        string updateResponseBody = await response.Content.ReadAsStringAsync();
        var updatedGame = JsonConvert.DeserializeObject<Game>(updateResponseBody) ?? new();
        createdId.Should().Be(updatedGame.Id, because: "the id of created game shall be equal to id of the updated one.");
        updatedGame.Name.Should().Be("Updated Test Name", because: "the name shall be updated.");
    }

    [Theory]
    [InlineData("")]
    [InlineData("{\"Name\":\"a\"}")]
    [InlineData("{\"Name\":\"thisisatoolongnamethatcannotbevalidbecausemaximumis32characters\"}")]
    public async Task BadRequest_WithInvalidPayload(string payload)
    {
        var responseBody = await GameUtility.CreateGame(_client);
        var createdId = int.Parse(responseBody);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        var url = $"{ApiUrl}/{createdId}";

        var response = await _client.PutAsync(url, content);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest, because: "Empty payload was provided.");
    }
}
