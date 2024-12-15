using DebercBackend.Infrastructure.Data;
using Testcontainers.MsSql;

namespace DebercBackend.IntegrationTests.Config;

public class MsSqlContainerFixture : IAsyncLifetime
{
    protected readonly MsSqlContainer _dbContainer = new MsSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var connectionString = _dbContainer.GetConnectionString();
        Environment.SetEnvironmentVariable("ConnectionStrings__MsSqlConnection", connectionString);

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        using var context = new AppDbContext(options, null);
        context.Database.Migrate();

        var sql = File.ReadAllText("./Data/Seed.sql");
        context.Database.ExecuteSqlRaw(sql);
    }
    public async Task DisposeAsync() => await _dbContainer.DisposeAsync();
}