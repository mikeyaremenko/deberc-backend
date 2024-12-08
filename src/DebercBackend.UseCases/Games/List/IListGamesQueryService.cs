using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.List;

public interface IListGamesQueryService
{
  Task<IEnumerable<Game>> ListAsync();
}
