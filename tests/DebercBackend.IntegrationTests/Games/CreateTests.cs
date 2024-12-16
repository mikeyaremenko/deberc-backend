using System.Net;
using System.Text;
using DebercBackend.IntegrationTests.Config;
using DebercBackend.IntegrationTests.Utilities;
using FluentAssertions;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerCollection")]
public class CreateTests(ITestOutputHelper helper) : BaseTest(helper)
{
    public override string ApiUrl => GameUtility.ApiUrl;

    [Fact]
    public async Task CreatesGame_WithValidPayload()
    {
        var responseBody = await GameUtility.CreateGame(_client);

        var createdId = int.Parse(responseBody);
        createdId.Should().BeGreaterThan(0, because: "the value must be positive and greater than zero.");
    }

    [Theory]
    [InlineData("")]
    [InlineData("{\"Name\":\"a\"}")]
    [InlineData("{\"Name\":\"thisisatoolongnamethatcannotbevalidbecausemaximumis32characters\"}")]
    public async Task BadRequest_WithInvalidPayload(string payload)
    {
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(ApiUrl, content);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest, because: "Empty payload was provided.");
    }
}
