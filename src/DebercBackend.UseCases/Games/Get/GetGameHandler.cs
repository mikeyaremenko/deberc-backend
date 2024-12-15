using DebercBackend.Core.GameAggregate;
using DebercBackend.Core.GameAggregate.Specifications;

namespace DebercBackend.UseCases.Games.Get;

public class GetGameHandler(IReadRepository<Game> _repository) : IQueryHandler<GetGameQuery, Result<Game>>
{
  public async Task<Result<Game>> Handle(GetGameQuery request, CancellationToken cancellationToken)
  {
    var spec = new GameByIdSpec(request.GameId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    return entity is null ? Result.NotFound() : entity;
  }
}
