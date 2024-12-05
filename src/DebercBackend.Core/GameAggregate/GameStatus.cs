namespace DebercBackend.Core.GameAggregate;

public class GameStatus : SmartEnum<GameStatus>
{
  public static readonly GameStatus Created = new(nameof(Created), 0);
  public static readonly GameStatus Started = new(nameof(Started), 1);
  public static readonly GameStatus Finished = new(nameof(Finished), 2);
  public static readonly GameStatus Cancelled = new(nameof(Cancelled), 3);

  protected GameStatus(string name, int value) : base(name, value) { }
}