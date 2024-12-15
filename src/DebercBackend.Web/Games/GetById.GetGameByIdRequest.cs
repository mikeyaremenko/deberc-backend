namespace DebercBackend.Web.Games;

public class GetGameByIdRequest
{
  public const string Route = "/Games/{id}";
  public static string BuildRoute(string id) => Route.Replace("{id}", id);

  public string Id { get; set; } = string.Empty;
}
