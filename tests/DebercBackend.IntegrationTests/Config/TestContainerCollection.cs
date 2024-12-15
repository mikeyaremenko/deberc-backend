namespace DebercBackend.IntegrationTests.Config;

[CollectionDefinition("TestContainerCollection")]
public class TestContainerCollection : ICollectionFixture<MsSqlContainerFixture>
{    
}
