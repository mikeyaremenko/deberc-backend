using System.ComponentModel.DataAnnotations;

namespace DebercBackend.Web.Games;

public class CreateGameRequest
{
  public const string Route = "/Games";

  [Required]
  public string Name { get; set; } = string.Empty;
}
