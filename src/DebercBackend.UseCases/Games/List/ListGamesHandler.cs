using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.List;

public class ListGamesHandler(IListGamesQueryService _query)
  : IQueryHandler<ListGamesQuery, Result<IEnumerable<Game>>>
{
  public async Task<Result<IEnumerable<Game>>> Handle(ListGamesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
