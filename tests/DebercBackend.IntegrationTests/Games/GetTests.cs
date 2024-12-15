using DebercBackend.IntegrationTests.Config;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerCollection")]
public class GetTests(ITestOutputHelper helper) : BaseTest(helper)
{
  public override string ApiUrl => "/api/v1/games";

  [Fact]
  public async Task ReturnsGame_WithValidId()
  {
    await AssertGetEndpointWithCustomIdf("1");
  }

  [Theory]
  [InlineData("-1")]
  [InlineData("0")]
  [InlineData("abc")]
  public async Task ReturnsNotFound_WithInvalidId(string id)
  {
    await AssertNotFoundWithCustomIdf(id);
  }
}
