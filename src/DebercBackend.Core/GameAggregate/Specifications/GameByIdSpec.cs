namespace DebercBackend.Core.GameAggregate.Specifications;

public class GameByIdSpec : Specification<Game>
{
  public GameByIdSpec(int gameId) =>
    Query
      .Where(game => game.Id== gameId)
      .Include(g => g.FirstTeam)
        .ThenInclude(t => t == null ? null : t.FirstPlayer)
      .Include(g => g.FirstTeam)
        .ThenInclude(t => t == null ? null : t.SecondPlayer)
      .Include(g => g.SecondTeam)
        .ThenInclude(t => t == null ? null : t.FirstPlayer)
      .Include(g => g.SecondTeam)
        .ThenInclude(t => t == null ? null : t.SecondPlayer)
      .Include(g => g.Dealer)
      .Include(g => g.Rounds);
}
