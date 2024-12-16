using System.ComponentModel.DataAnnotations;

namespace DebercBackend.Web.Games;

public class UpdateGameRequest
{
  public const string Route = "/Games/{GameId:int}";
  public static string BuildRoute(int gameId) => Route.Replace("{GameId:int}", gameId.ToString());

  [Required]
  public int GameId { get; set; }
  [Required]
  public string? Name { get; set; }
}
