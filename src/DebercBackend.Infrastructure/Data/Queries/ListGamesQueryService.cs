using DebercBackend.Core.GameAggregate;
using DebercBackend.UseCases.Games.List;

namespace DebercBackend.Infrastructure.Data.Queries;

public class ListGamesQueryService(AppDbContext _db) : IListGamesQueryService
{
  public async Task<IEnumerable<Game>> ListAsync()
  {
    var games = await _db.Games
    .Include(g => g.FirstTeam)
        .ThenInclude(t => t == null ? null : t.FirstPlayer)
    .Include(g => g.FirstTeam)
        .ThenInclude(t => t == null ? null : t.SecondPlayer)
    .Include(g => g.SecondTeam)
        .ThenInclude(t => t == null ? null : t.FirstPlayer)
    .Include(g => g.SecondTeam)
        .ThenInclude(t => t == null ? null : t.SecondPlayer)
    .Include(g => g.Dealer)
    .Include(g => g.Rounds)
    .Where(g => g.Status == GameStatus.Created)
    .ToListAsync();

    return games;
  }
}
