using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DebercBackend.IntegrationTests.Utilities;

public static partial class Verifier
{
  private const string VerifyFolder = "VerifiedResponses";

  public static Task VerifyResponse(this string responseContent)
  {
    var settings = new VerifySettings();
    settings.UseDirectory(VerifyFolder);
    responseContent = IdRegex().Replace(responseContent, replacement: "\"id\": \"\"");
    responseContent = IdfRegex().Replace(responseContent, replacement: "\"idf\": \"\"");
    responseContent = CreatedDateRegex().Replace(responseContent, replacement: "\"createdDate\": \"\"");

    var formattedJson = FormatJson(responseContent);

    return Verify(formattedJson, settings);
  }

  [GeneratedRegex(@"""id"":\s*""[^""]*""")]
  private static partial Regex IdRegex();

  [GeneratedRegex(@"""idf"":\s*""[^""]*""")]
  private static partial Regex IdfRegex();

  [GeneratedRegex(@"""createdDate"":\s*""[^""]*""")]
  private static partial Regex CreatedDateRegex();

  private static string FormatJson(string json)
  {
    using var jsonDoc = JsonDocument.Parse(json);
    var options = new JsonSerializerOptions
    {
      WriteIndented = true,
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    return JsonSerializer.Serialize(jsonDoc, options);
  }
}
