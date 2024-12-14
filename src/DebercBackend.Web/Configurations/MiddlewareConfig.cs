using Ardalis.ListStartupServices;
using Ardalis.SmartEnum.JsonNet;
using DebercBackend.Core.GameAggregate;

namespace DebercBackend.Web.Configurations;

public static class MiddlewareConfig
{
  public static IApplicationBuilder UseAppMiddlewareAndSeedDatabase(this WebApplication app)
  {
    if (app.Environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
    }
    else
    {
      app.UseDefaultExceptionHandler(); // from FastEndpoints
      app.UseHsts();
    }

    app.UseFastEndpoints(config =>
      {
        config.Endpoints.RoutePrefix = "api/v1";
        config.Serializer.RequestDeserializer = async (req, tDto, jCtx, ct) =>
        {
          var settings = new Newtonsoft.Json.JsonSerializerSettings();
          settings.Converters.Add(new SmartEnumNameConverter<GameStatus, int>());
          settings.Converters.Add(new SmartEnumNameConverter<CombinationType, int>());
          using var reader = new StreamReader(req.Body);
          return Newtonsoft.Json.JsonConvert.DeserializeObject(await reader.ReadToEndAsync(ct), tDto, settings);
        };
        config.Serializer.ResponseSerializer = (rsp, dto, cType, jCtx, ct) =>
        {
          var settings = new Newtonsoft.Json.JsonSerializerSettings
          {
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
          };
          rsp.ContentType = cType;
          return rsp.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(dto, settings), ct);
        };
      })
      .UseSwaggerGen();


    app.UseHttpsRedirection(); // Note this will drop Authorization headers

    return app;
  }
}
