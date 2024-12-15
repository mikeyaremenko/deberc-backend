using DebercBackend.IntegrationTests.Config;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerCollection")]
public class ListTests(ITestOutputHelper helper) : BaseTest(helper)
{ 
  public override string ApiUrl => "/api/v1/games";

  [Fact]
  public async Task ReturnsGameList()
  {
    await AssertGetEndpointWithoutIdf();
  }
}
