using System.Net;
using DebercBackend.IntegrationTests.Utilities;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Config;

public abstract class BaseTest
{
  protected readonly HttpClient _client;
  protected readonly TestWebApplicationFactory _factory;

  public abstract string ApiUrl { get; }

  protected BaseTest(ITestOutputHelper testOutputHelper)
  {
    _factory = new TestWebApplicationFactory(testOutputHelper);
    _client = _factory.CreateClient();
  }

  protected async Task AssertGetEndpointWithoutIdf()
      => await AssertGetEndpoint(withId: false);
  protected async Task AssertGetEndpointWithCustomIdf(string customIdf)
      => await AssertGetEndpoint(withId: true, customIdf);

  private async Task AssertGetEndpoint(bool withId, string? customIdf = null)
  {
    var url = withId ? $"{ApiUrl}/{customIdf}" : ApiUrl;
    var response = await _client.GetAsync(url);

    var responseContent = await response.Content.ReadAsStringAsync();

    await responseContent.VerifyResponse();
  }

  protected async Task AssertBadRequest(string customId)
    => await AssertResponseCode(HttpStatusCode.BadRequest, customId);
  protected async Task AssertNotFound(string customId)
    => await AssertResponseCode(HttpStatusCode.NotFound, customId);

  private async Task AssertResponseCode(HttpStatusCode code, string customId)
  {
    var url = $"{ApiUrl}/{customId}";
    var response = await _client.GetAsync(url);

    Assert.Equal(code, response.StatusCode);
  }

  protected static async Task AssertEmptyResponse(HttpResponseMessage response)
  {
    var responseContent = await response.Content.ReadAsStringAsync();
    Assert.True(string.IsNullOrEmpty(responseContent), $"Expected response to be empty, but got: {responseContent}");
  }

  protected static string EncodeHeader(string plainText)
  {
    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
    return Convert.ToBase64String(plainTextBytes);
  }
}
