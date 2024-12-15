using System.Net;
using DebercBackend.IntegrationTests.Utilities;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Config;

public abstract class BaseTest
{
  protected const string DefaultIdf = "0000129";
  protected const string InvalidIdf = "invalid";
  protected const string NotExistingIdf = "0000000";

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
    var url = withId ? $"{ApiUrl}/{DefaultIdf}" : ApiUrl;
    if (customIdf is not null)
    {
      url = $"{ApiUrl}/{customIdf}";
    }
    var response = await _client.GetAsync(url);

    var responseContent = await response.Content.ReadAsStringAsync();

    await responseContent.VerifyResponse();
  }

  protected async Task AssertBadRequest() => await AssertResponseCode(HttpStatusCode.BadRequest);
  protected async Task AssertBadRequestWithCustomIdf(string customId, string? urlSuffix = null)
    => await AssertResponseCode(HttpStatusCode.BadRequest, customId, urlSuffix);
  protected async Task AssertNotFound() => await AssertResponseCode(HttpStatusCode.NotFound);
  protected async Task AssertNotFoundWithCustomIdf(string customId, string? urlSuffix = null)
    => await AssertResponseCode(HttpStatusCode.NotFound, customId, urlSuffix);

  private async Task AssertResponseCode(HttpStatusCode code, string? customId = null, string? urlSuffix = null)
  {
    var idf = code == HttpStatusCode.BadRequest ? InvalidIdf : NotExistingIdf;
    if (customId is not null)
    {
      idf = customId;
    }
    var url = urlSuffix is null ? $"{ApiUrl}/{idf}" : $"{ApiUrl}/{idf}/{urlSuffix}";
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
