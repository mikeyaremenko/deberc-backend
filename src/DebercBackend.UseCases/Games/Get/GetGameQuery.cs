using DebercBackend.Core.GameAggregate;

namespace DebercBackend.UseCases.Games.Get;

public record GetGameQuery(int GameId) : IQuery<Result<Game>>;
