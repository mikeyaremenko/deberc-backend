using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Games;

[Collection("TestContainerFixture")]
public class ListTests(ITestOutputHelper helper) : BaseTest(helper)
{
  public override string ApiUrl => "/api/v1/games";

  [Fact]
  public async Task Returns_GameList()
  {
    await AssertGetEndpointWithoutIdf();
    Assert.True(true);
  }
}
