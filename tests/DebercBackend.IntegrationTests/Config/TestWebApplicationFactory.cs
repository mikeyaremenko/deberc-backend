using Meziantou.Extensions.Logging.Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace DebercBackend.IntegrationTests.Config;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
  private readonly IConfiguration _configuration;
  private readonly ITestOutputHelper _testOutputHelper;

  public TestWebApplicationFactory(ITestOutputHelper testOutputHelper)
  {
    _testOutputHelper = testOutputHelper;

    using var scope = Services.CreateScope();
    _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
  }

  public string GetConfigurationValue(string key) => _configuration.GetSection(key).Value ?? "invalid";

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.UseEnvironment(Environments.Development);

    builder.ConfigureLogging(x =>
    {
      x.ClearProviders();

      x.SetMinimumLevel(LogLevel.Warning);
      x.Services.AddSingleton<ILoggerProvider>(new XUnitLoggerProvider(_testOutputHelper));
    });
  }
}
