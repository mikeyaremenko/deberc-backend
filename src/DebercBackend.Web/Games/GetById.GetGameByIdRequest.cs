﻿namespace DebercBackend.Web.Games;

public class GetGameByIdRequest
{ 
  public const string Route = "/Games/{GameId:int}";
  
  public static string BuildRoute(int gameId) => Route.Replace("{GameId:int}", gameId.ToString());

  public int GameId { get; set; }
}
