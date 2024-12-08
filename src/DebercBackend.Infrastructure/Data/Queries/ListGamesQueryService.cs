using DebercBackend.Core.GameAggregate;
using DebercBackend.UseCases.Games.List;

namespace DebercBackend.Infrastructure.Data.Queries;

public class ListGamesQueryService(AppDbContext _db) : IListGamesQueryService
{
  public async Task<IEnumerable<Game>> ListAsync()
  {
    var games = await _db.Games
      .Include(g => g.FirstTeam)
      .Include(g => g.SecondTeam)
      .Include(g => g.Dealer)      
      .Include(g => g.Rounds)
      .Where(g => g.Status == GameStatus.Created)
      .ToListAsync();

    return games;
  }
}
